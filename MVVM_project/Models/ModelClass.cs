using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text.Json;

namespace MVVM_project.Models
{
    public class ModelClass
    {
        private double a, b, result;
        private DateTime date;

        public double Result
        {
            get { return result; }
            set { result = value; }
        }

        public double A
        {
            set
            {
                a = value;
                UpdateResult();

            }
            get { return a; }
        }

        public double B
        {
            set
            {
                b = value;
                UpdateResult();
            }
            get { return b; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public ModelClass() { }

        public ModelClass(double A, double B)
        {
            a = A;
            b = B;
            UpdateResult();
        }

        private void UpdateResult()
        {
            Result = A + B;
            date = DateTime.Now;
        }
    }
}