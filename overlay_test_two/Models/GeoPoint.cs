using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Everlive.Sdk.Core.Model.Base;

namespace overlay_test_two.Models
{
    class GeoPoint : DataItem
    {
        private string title;
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
                this.OnPropertyChanged("Title");
            }

        }

        private GeoLoc location;
        public GeoLoc Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
                this.OnPropertyChanged("Location");
            }

        }

     
    }
}
