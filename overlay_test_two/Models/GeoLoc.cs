using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Everlive.Sdk.Core.Model.Base;

namespace overlay_test_two.Models
{
    class GeoLoc : DataItem
    {
        private double latitude;
        public double Latitude
        {
            get
            {
                return this.latitude;
            }
            set
            {
                this.latitude = value;
                this.OnPropertyChanged("Latitude");
            }

        }

        private double longitude;
        public double Longitude
        {
            get
            {
                return this.longitude;
            }
            set
            {
                this.longitude = value;
                this.OnPropertyChanged("Longitude");
            }

        }
    }
}
