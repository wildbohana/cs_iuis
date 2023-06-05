﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using NetworkService.Helpers;
using NetworkService.Models;

namespace NetworkService.ViewModel
{
    public class NetworkDisplayViewModel : BindableBase
    {
        // TODO dodaj treeview svih entiteta

        public BindingList<Reaktor> EntitiesInList { get; set; }

        // TODO šta je ovo?
        //public EntityByExtension listaRtd = new EntityByExtension() { Extension = "RTD" };
        //public EntityByExtension listaSprega = new EntityByExtension() { Extension = "Sprega" };

        #region POLJA
        public ObservableCollection<Canvas> CanvasCollection { get; set; }
        public ObservableCollection<MyLine> LineCollection { get; set; }
        public ObservableCollection<Brush> BorderBrushCollection { get; set; }

        private Reaktor selectedEntity;

        private Reaktor draggedItem = null;
        private bool dragging = false;
        public int draggingSourceIndex = -1;

        public MyICommand<object> DropEntityOnCanvas { get; set; }
        public MyICommand<object> LeftMouseButtonDownOnCanvas { get; set; }
        public MyICommand MouseLeftButtonUp { get; set; }
        public MyICommand<object> SelectionChanged { get; set; }
        public MyICommand<object> OslobodiCanvas { get; set; }
        public MyICommand<object> RightMouseButtonDownOnCanvas { get; set; }

        private bool isLineSourceSelected = false;
        private int sourceCanvasIndex = -1;
        private int destinationCanvasIndex = -1;
        private MyLine currentLine = new MyLine();
        private Point linePoint1 = new Point();
        private Point linePoint2 = new Point();

        public NetworkDisplayViewModel()
        {
            //EntitiesInList = new BindingList<Reaktor>();
            EntitiesInList = new BindingList<Reaktor>();

            CanvasCollection = new ObservableCollection<Canvas>();
            for (int i = 0; i < 12; i++)
            {
                CanvasCollection.Add(new Canvas()
                {
                    Background = (Brush)(new BrushConverter().ConvertFrom("#8B9DC3")),
                    AllowDrop = true
                });
            }

            BorderBrushCollection = new ObservableCollection<Brush>();
            for (int i = 0; i < 12; i++)
            {
                BorderBrushCollection.Add((Brush)(new BrushConverter().ConvertFrom("#282B30")));
            }

            LineCollection = new ObservableCollection<MyLine>();

            DropEntityOnCanvas = new MyICommand<object>(OnDrop);
            LeftMouseButtonDownOnCanvas = new MyICommand<object>(OnLeftMouseButtonDown);
            MouseLeftButtonUp = new MyICommand(OnMouseLeftButtonUp);
            SelectionChanged = new MyICommand<object>(OnSelectionChanged);
            OslobodiCanvas = new MyICommand<object>(OnOslobodiCanvas);
            RightMouseButtonDownOnCanvas = new MyICommand<object>(OnRightMouseButtonDown);
        }

        public Reaktor SelectedEntity
        {
            get { return selectedEntity; }
            set
            {
                selectedEntity = value;
                OnPropertyChanged("SelectedEntity");
            }
        }
        #endregion

        #region EVENTI
        private void OnDrop(object parameter)
        {
            if (draggedItem != null)
            {
                int index = Convert.ToInt32(parameter);

                if (CanvasCollection[index].Resources["taken"] == null)
                {
                    BitmapImage logo = new BitmapImage();
                    logo.BeginInit();
                    logo.UriSource = new Uri(draggedItem.Tip.Slika, UriKind.RelativeOrAbsolute);
                    logo.EndInit();

                    CanvasCollection[index].Background = new ImageBrush(logo);
                    CanvasCollection[index].Resources.Add("taken", true);
                    CanvasCollection[index].Resources.Add("data", draggedItem);
                    BorderBrushCollection[index] = (draggedItem.IsValueValidForType()) ? Brushes.GreenYellow : Brushes.Crimson;

                    // drag from another
                    if (draggingSourceIndex != -1)
                    {
                        CanvasCollection[draggingSourceIndex].Background = (Brush)(new BrushConverter().ConvertFrom("#8B9DC3"));
                        CanvasCollection[draggingSourceIndex].Resources.Remove("taken");
                        CanvasCollection[draggingSourceIndex].Resources.Remove("data");
                        BorderBrushCollection[draggingSourceIndex] = (Brush)(new BrushConverter().ConvertFrom("#282B30"));

                        UpdateLinesForCanvas(draggingSourceIndex, index);

                        // break line if moved
                        if (sourceCanvasIndex != -1)
                        {
                            isLineSourceSelected = false;
                            sourceCanvasIndex = -1;
                            linePoint1 = new Point();
                            linePoint2 = new Point();
                            currentLine = new MyLine();
                        }

                        draggingSourceIndex = -1;
                    }

                    // drag itself
                    if (EntitiesInList.Contains(draggedItem))
                    {
                        EntitiesInList.Remove(draggedItem);
                    }
                }
            }
        }

        private void OnLeftMouseButtonDown(object parameter)
        {
            if (!dragging)
            {
                int index = Convert.ToInt32(parameter);

                if (CanvasCollection[index].Resources["taken"] != null)
                {
                    dragging = true;
                    draggedItem = (Reaktor)(CanvasCollection[index].Resources["data"]);
                    draggingSourceIndex = index;
                    DragDrop.DoDragDrop(CanvasCollection[index], draggedItem, DragDropEffects.Move);
                }
            }
        }

        private void OnMouseLeftButtonUp()
        {
            draggedItem = null;
            SelectedEntity = null;
            dragging = false;
            draggingSourceIndex = -1;
        }

        private void OnSelectionChanged(object parameter)
        {
            if (!dragging)
            {
                dragging = true;
                draggedItem = SelectedEntity;
                DragDrop.DoDragDrop((ListView)parameter, draggedItem, DragDropEffects.Move);
            }
        }

        private void OnOslobodiCanvas(object parameter)
        {
            int index = Convert.ToInt32(parameter);

            if (CanvasCollection[index].Resources["taken"] != null)
            {
                // break line if remove
                if (sourceCanvasIndex != -1)
                {
                    isLineSourceSelected = false;
                    sourceCanvasIndex = -1;
                    linePoint1 = new Point();
                    linePoint2 = new Point();
                    currentLine = new MyLine();
                }

                DeleteLinesForCanvas(index);

                EntitiesInList.Add((Reaktor)CanvasCollection[index].Resources["data"]);
                CanvasCollection[index].Background = (Brush)(new BrushConverter().ConvertFrom("#8B9DC3"));
                CanvasCollection[index].Resources.Remove("taken");
                CanvasCollection[index].Resources.Remove("data");
                BorderBrushCollection[index] = (Brush)(new BrushConverter().ConvertFrom("#282B30"));
            }
        }

        private void OnRightMouseButtonDown(object parameter)
        {
            int index = Convert.ToInt32(parameter);

            if (CanvasCollection[index].Resources["taken"] != null)
            {
                if (!isLineSourceSelected)
                {
                    sourceCanvasIndex = index;

                    linePoint1 = GetPointForCanvasIndex(sourceCanvasIndex);

                    currentLine.X1 = linePoint1.X;
                    currentLine.Y1 = linePoint1.Y;
                    currentLine.Source = sourceCanvasIndex;

                    isLineSourceSelected = true;
                }
                else
                {
                    destinationCanvasIndex = index;

                    if ((sourceCanvasIndex != destinationCanvasIndex) && !DoesLineAlreadyExist(sourceCanvasIndex, destinationCanvasIndex))
                    {
                        linePoint2 = GetPointForCanvasIndex(destinationCanvasIndex);

                        currentLine.X2 = linePoint2.X;
                        currentLine.Y2 = linePoint2.Y;
                        currentLine.Destination = destinationCanvasIndex;

                        LineCollection.Add(new MyLine
                        {
                            X1 = currentLine.X1,
                            Y1 = currentLine.Y1,
                            X2 = currentLine.X2,
                            Y2 = currentLine.Y2,
                            Source = currentLine.Source,
                            Destination = currentLine.Destination
                        });

                        isLineSourceSelected = false;

                        linePoint1 = new Point();
                        linePoint2 = new Point();
                        currentLine = new MyLine();
                    }
                    else
                    {
                        // alfa and omega should be diff
                        isLineSourceSelected = false;

                        linePoint1 = new Point();
                        linePoint2 = new Point();
                        currentLine = new MyLine();
                    }
                }
            }
            else
            {
                // source is empty?
                isLineSourceSelected = false;

                linePoint1 = new Point();
                linePoint2 = new Point();
                currentLine = new MyLine();
            }
        }

        // Connect Source and Destination
        private void UpdateLinesForCanvas(int sourceCanvas, int destinationCanvas)
        {
            for (int i = 0; i < LineCollection.Count; i++)
            {
                if (LineCollection[i].Source == sourceCanvas)
                {
                    Point newSourcePoint = GetPointForCanvasIndex(destinationCanvas);
                    LineCollection[i].X1 = newSourcePoint.X;
                    LineCollection[i].Y1 = newSourcePoint.Y;
                    LineCollection[i].Source = destinationCanvas;
                }
                else if (LineCollection[i].Destination == sourceCanvas)
                {
                    Point newDestinationPoint = GetPointForCanvasIndex(destinationCanvas);
                    LineCollection[i].X2 = newDestinationPoint.X;
                    LineCollection[i].Y2 = newDestinationPoint.Y;
                    LineCollection[i].Destination = destinationCanvas;
                }
            }
        }
        #endregion

        #region VALIDACIJE
        private bool IsCanvasConnected(int canvasIndex)
        {
            foreach (MyLine line in LineCollection)
            {
                if ((line.Source == canvasIndex) || (line.Destination == canvasIndex))
                {
                    return true;
                }
            }
            return false;
        }

        private bool DoesLineAlreadyExist(int source, int destination)
        {
            foreach (MyLine line in LineCollection)
            {
                if ((line.Source == source) && (line.Destination == destination))
                {
                    return true;
                }
                if ((line.Source == destination) && (line.Destination == source))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region METODE
        public void DeleteEntityFromCanvas(Reaktor entity)
        {
            int canvasIndex = GetCanvasIndexForEntityId(entity.Id);

            if (canvasIndex != -1)
            {
                CanvasCollection[canvasIndex].Background = (Brush)(new BrushConverter().ConvertFrom("#8B9DC3"));
                CanvasCollection[canvasIndex].Resources.Remove("taken");
                CanvasCollection[canvasIndex].Resources.Remove("data");
                BorderBrushCollection[canvasIndex] = (Brush)(new BrushConverter().ConvertFrom("#282B30"));

                DeleteLinesForCanvas(canvasIndex);
            }
        }

        private void DeleteLinesForCanvas(int canvasIndex)
        {
            List<MyLine> linesToDelete = new List<MyLine>();

            for (int i = 0; i < LineCollection.Count; i++)
            {
                if ((LineCollection[i].Source == canvasIndex) || (LineCollection[i].Destination == canvasIndex))
                {
                    linesToDelete.Add(LineCollection[i]);
                }
            }

            foreach (MyLine line in linesToDelete)
            {
                LineCollection.Remove(line);
            }
        }

        // Central point for canvas
        private Point GetPointForCanvasIndex(int canvasIndex)
        {
            double x = 0, y = 0;

            for (int row = 0; row <= 3; row++)
            {
                for (int col = 0; col <= 2; col++)
                {
                    int currentIndex = row * 3 + col;

                    if (canvasIndex == currentIndex)
                    {
                        x = 44 + (col * 88);
                        y = 44 + (row * 88);

                        break;
                    }
                }
            }
            return new Point(x, y);
        }

        public int GetCanvasIndexForEntityId(int entityId)
        {
            for (int i = 0; i < CanvasCollection.Count; i++)
            {
                Reaktor entity = (CanvasCollection[i].Resources["data"]) as Reaktor;

                if ((entity != null) && (entity.Id == entityId))
                {
                    return i;
                }
            }
            return -1;
        }

        // MainWindowViewModel update
        public void UpdateEntityOnCanvas(Reaktor entity)
        {
            int canvasIndex = GetCanvasIndexForEntityId(entity.Id);

            if (canvasIndex != -1)
            {
                if (entity.IsValueValidForType())
                {
                    BorderBrushCollection[canvasIndex] = Brushes.GreenYellow;
                }
                else
                {
                    BorderBrushCollection[canvasIndex] = Brushes.Crimson;
                }
            }
        }
        #endregion
    }
}
