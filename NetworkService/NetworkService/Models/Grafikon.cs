using NetworkService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO izmei ovo, pregledaj, skontaj šta je šta
namespace NetworkService.Models
{
    public class Grafikon : BindableBase
    {
        #region PRVI
        private double firstBindingPoint;
        public double FirstBindingPoint
        {
            get { return firstBindingPoint; }
            set
            {
                SecondBindingPoint = firstBindingPoint;
                firstBindingPoint = value;
                OnPropertyChanged("FirstBindingPoint");
            }
        }

        private string firstBindingPoint2;
        public string FirstBindingPoint2
        {
            get { return firstBindingPoint2; }
            set
            {
                SecondBindingPoint2 = firstBindingPoint2;
                firstBindingPoint2 = value;
                OnPropertyChanged("FirstBindingPoint2");
            }
        }
        #endregion

        #region DRUGI
        private double secondBindingPoint;
        public double SecondBindingPoint
        {
            get { return secondBindingPoint; }
            set
            {
                ThirdBindingPoint = secondBindingPoint;
                secondBindingPoint = value;
                OnPropertyChanged("SecondBindingPoint");
            }
        }

        private string secondBindingPoint2;
        public string SecondBindingPoint2
        {
            get { return secondBindingPoint2; }
            set
            {
                ThirdBindingPoint2 = secondBindingPoint2;
                secondBindingPoint2 = value; ;
                OnPropertyChanged("SecondBindingPoint2");
            }
        }
        #endregion

        #region  TREĆI
        private double thirdBindingPoint;
        public double ThirdBindingPoint
        {
            get { return thirdBindingPoint; }
            set
            {
                FourthBindingPoint = thirdBindingPoint;
                thirdBindingPoint = value;
                OnPropertyChanged("ThirdBindingPoint");
            }
        }

        private string thirdBindingPoint2;
        public string ThirdBindingPoint2
        {
            get { return thirdBindingPoint2; }
            set
            {
                FourthBindingPoint2 = thirdBindingPoint2;
                thirdBindingPoint2 = value;
                OnPropertyChanged("ThirdBindingPoint2");
            }
        }
        #endregion

        #region ČETVRTI
        private double fourthBindingPoint;
        public double FourthBindingPoint
        {
            get { return fourthBindingPoint; }
            set
            {
                FifthBindingPoint = fourthBindingPoint;
                fourthBindingPoint = value;
                OnPropertyChanged("FourthBindingPoint");
            }
        }

        private string fourthBindingPoint2;
        public string FourthBindingPoint2
        {
            get { return fourthBindingPoint2; }
            set
            {
                FifthBindingPoint2 = fourthBindingPoint2;
                fourthBindingPoint2 = value;
                OnPropertyChanged("FourthBindingPoint2");
            }
        }
        #endregion

        #region PETI
        private double fifthBindingPoint;
        public double FifthBindingPoint
        {
            get { return fifthBindingPoint; }
            set
            {
                fifthBindingPoint = value;
                OnPropertyChanged("FifthBindingPoint");
            }
        }

        private string fifthBindingPoint2;
        public string FifthBindingPoint2
        {
            get { return fifthBindingPoint2; }
            set
            {
                fifthBindingPoint2 = value;
                OnPropertyChanged("FifthBindingPoint2");
            }
        }
        #endregion
    }
}
