using System;
using System.Collections.ObjectModel;
using System.Device.Location;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using Telerik.Everlive.Sdk.Core;
using Telerik.Windows.Controls;
using System.Windows.Controls;
using System.Threading.Tasks;
using overlay_test_two.Models;

namespace overlay_test_two
{
    public partial class MainPage : PhoneApplicationPage
    {
       /* MapOverlay songOverlay;
        MapOverlay picOverlay;
        MapOverlay vidOverlay;
        MapOverlay poemOverlay;*/

        MapLayer songLayer;
        MapLayer picLayer;
        MapLayer vidLayer;
        MapLayer poemLayer;

        ObservableCollection<MapOverlay> songOverlays;
        ObservableCollection<MapOverlay> picOverlays;
        ObservableCollection<MapOverlay> vidOverlays;
        ObservableCollection<MapOverlay> poemOverlays;

        bool removeSongOverlay;
        bool removePicOverlay;
        bool removeVidOverlay;
        bool removePoemOverlay;

        EverliveApp everApp;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

			//Shows the rate reminder message, according to the settings of the RateReminder.
            (App.Current as App).rateReminder.Notify();


             everApp = new EverliveApp("jvPa7RY3Rnf54Xrd");




            //INIT OVERLAYS
            /*
            songOverlay = new MapOverlay
            {
                GeoCoordinate = myMap.Center,
                Content = new Ellipse
                {
                    Fill = new SolidColorBrush(Colors.Red),
                    Width = 40,
                    Height = 40
                }
            };
            picOverlay = new MapOverlay
            {
                GeoCoordinate = myMap.Center,
                Content = new Rectangle
                {
                    Fill = new SolidColorBrush(Colors.Blue),
                    Width = 40,
                    Height = 40
                }
            };
            vidOverlay = new MapOverlay
            {
                GeoCoordinate = myMap.Center,
                Content = new Rectangle
                {
                    Fill = new SolidColorBrush(Colors.Green),
                    Width = 45,
                    Height = 30
                }
            };
            poemOverlay = new MapOverlay
            {
                GeoCoordinate = myMap.Center,
                Content = new Rectangle
                {
                    Fill = new SolidColorBrush(Colors.Orange),
                    Width = 45,
                    Height = 30
                }
            };*/

            //INIT LAYERS
            //[0] - SONG
            songLayer = new MapLayer();
            myMap.Layers.Add(songLayer);
            removeSongOverlay = true;

            //[1] - PIC
            picLayer = new MapLayer();
            myMap.Layers.Add(picLayer);
            removePicOverlay = true;

            //[2] - VID
            vidLayer = new MapLayer();
            myMap.Layers.Add(vidLayer);
            removeVidOverlay = true;

            //[3] - POEM
            poemLayer = new MapLayer();
            myMap.Layers.Add(poemLayer);
            removePoemOverlay = true;


            songOverlays = new ObservableCollection<MapOverlay>();
            picOverlays = new ObservableCollection<MapOverlay>();
            vidOverlays = new ObservableCollection<MapOverlay>();
            poemOverlays = new ObservableCollection<MapOverlay>();
            
        }


        //crc
        private async void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            foreach (MapOverlay mo in myMap.Layers[0])
            {
                if (!songOverlays.Contains<MapOverlay>(mo))
                    songOverlays.Add(mo);

            }

            if (removeSongOverlay)
            {
                songLayer.Clear();
                removeSongOverlay = false;
            }
            else
            {
                foreach (MapOverlay mo in songOverlays)
                {
                    songLayer.Add(mo);
                }
                removeSongOverlay = true;

                await saveItems(songOverlays);

            }
        }
  
        private async Task saveItems(ObservableCollection<MapOverlay> songOverlays)
        {
            foreach (MapOverlay mo in songOverlays)
            {
                GeoPoint g = new GeoPoint();
                g.Title = "Name";
                g.Location = new GeoLoc
                {
                    Latitude= 3.3,
                    Longitude= 4.4
                };
                await everApp.WorkWith().Data<GeoPoint>().Create(g).ExecuteAsync();
            }

        }

        //sq
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            foreach (MapOverlay mo in myMap.Layers[1])
            {
                if (!picOverlays.Contains<MapOverlay>(mo))
                    picOverlays.Add(mo);
            }

            if (removePicOverlay)
            {
                picLayer.Clear();
                removePicOverlay = false;

            }
            else
            {
                foreach (MapOverlay mo in picOverlays)
                {
                    picLayer.Add(mo);
                }
                removePicOverlay = true;
            }
        }
        //rct
        private void ApplicationBarIconButton_Click_2(object sender, EventArgs e)
        {
           foreach (MapOverlay mo in myMap.Layers[2])
            {
                if (!vidOverlays.Contains<MapOverlay>(mo))
                    vidOverlays.Add(mo);
            }

            if (removeVidOverlay)
            {
                vidLayer.Clear();
                removeVidOverlay = false;

            }
            else
            {
                foreach (MapOverlay mo in vidOverlays)
                {
                    vidLayer.Add(mo);
                }
                removeVidOverlay = true;
            }
        }

        private void ApplicationBarIconButton_Click_3(object sender, EventArgs e)
        {
            foreach (MapOverlay mo in myMap.Layers[3])
            {
                if (!poemOverlays.Contains<MapOverlay>(mo))
                    poemOverlays.Add(mo);
            }

            if (removePoemOverlay)
            {
                poemLayer.Clear();
                removePoemOverlay = false;

            }
            else
            {
                foreach (MapOverlay mo in poemOverlays)
                {
                    poemLayer.Add(mo);
                }
                removePoemOverlay = true;
            }
        }

        /*  Pushpins
            UserLocationMarker marker = (UserLocationMarker)this.FindName("UserLocationMarker");
            marker.GeoCoordinate = myMap.Center;
 
            Pushpin pushpin = (Pushpin)this.FindName("MyPushpin");          
            pushpin.GeoCoordinate = new GeoCoordinate(30.712474, -132.32691);

            */

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            myMap.Tap -= myMap_TapPoem;
            myMap.Tap -= myMap_TapVid;
            myMap.Tap -= myMap_TapPic;
            myMap.Tap += myMap_TapSong;
        }

        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {
            myMap.Tap -= myMap_TapSong;
            myMap.Tap -= myMap_TapVid;
            myMap.Tap -= myMap_TapPoem;
            myMap.Tap += myMap_TapPic;
        }

        private void ApplicationBarMenuItem_Click_2(object sender, EventArgs e)
        {
            myMap.Tap -= myMap_TapSong;
            myMap.Tap -= myMap_TapPic;
            myMap.Tap -= myMap_TapPoem;
            myMap.Tap += myMap_TapVid;
        }

        private void ApplicationBarMenuItem_Click_3(object sender, EventArgs e)
        {
            myMap.Tap -= myMap_TapSong;
            myMap.Tap -= myMap_TapVid;
            myMap.Tap -= myMap_TapPic;
            myMap.Tap += myMap_TapPoem;
        }

        void myMap_TapSong(object sender, System.Windows.Input.GestureEventArgs e)
        {
            GeoCoordinate asd = this.myMap.ConvertViewportPointToGeoCoordinate(e.GetPosition(this.myMap));

            var grid = new Grid
            {
                Width = 75,
                Height = 75,
                Margin = new System.Windows.Thickness(-25, -25, 0, 0)
            };
            var backimg = new Image
                {
                    Source = new BitmapImage
                    {
                        UriSource = new Uri("/Assets/appbar.music.png", UriKind.Relative)
                    },
                    Clip = new EllipseGeometry
                    {
                        RadiusX = 28,
                        RadiusY = 28,
                        Center = new System.Windows.Point(37, 37),
                    }
                };
            var circ = new Ellipse
                {
                    Fill = new SolidColorBrush(Colors.Purple),
                    Width = 42,
                    Height = 42
                };
            grid.Children.Add(circ);
            grid.Children.Add(backimg);

            MapOverlay songOverlay = new MapOverlay
            {
                GeoCoordinate = asd,
                Content = grid
            };

            if (removeSongOverlay) songLayer.Add(songOverlay);
            else songOverlays.Add(songOverlay);
            myMap.Tap -= myMap_TapSong;
        }
        void myMap_TapPic(object sender, System.Windows.Input.GestureEventArgs e)
        {
            GeoCoordinate asd = this.myMap.ConvertViewportPointToGeoCoordinate(e.GetPosition(this.myMap));

            var grid = new Grid
            {
                Width = 75,
                Height = 75,
                Margin = new System.Windows.Thickness(-25, -25, 0, 0)
            };
            var backimg = new Image
                {
                    Source = new BitmapImage
                    {
                        UriSource = new Uri("/Assets/appbar.image.png", UriKind.Relative)
                    },
                    Clip = new EllipseGeometry
                    {
                        RadiusX = 28,
                        RadiusY = 28,
                        Center = new System.Windows.Point(37, 37),
                    }
                };
            var circ = new Rectangle
                {
                    Fill = new SolidColorBrush(Colors.Green),
                    Width = 40,
                    Height = 36
                };
            grid.Children.Add(circ);
            grid.Children.Add(backimg);

            MapOverlay picOverlay = new MapOverlay
            {
                GeoCoordinate = asd,
                Content = grid
            };

            if (removePicOverlay) picLayer.Add(picOverlay);
            else picOverlays.Add(picOverlay);
            myMap.Tap -= myMap_TapPic;
        }
        void myMap_TapVid(object sender, System.Windows.Input.GestureEventArgs e)
        {
            GeoCoordinate asd = this.myMap.ConvertViewportPointToGeoCoordinate(e.GetPosition(this.myMap));
            var grid = new Grid
            {
                Width = 75,
                Height = 75,
                Margin = new System.Windows.Thickness(-25, -25, 0, 0)
            };
            var backimg = new Image
                {
                    Source = new BitmapImage
                    {
                        UriSource = new Uri("/Assets/appbar.video.png", UriKind.Relative)
                    },
                    Clip = new EllipseGeometry
                    {
                        RadiusX = 28,
                        RadiusY = 28,
                        Center = new System.Windows.Point(37, 37),
                    }
                };
            var circ = new Ellipse
                {
                    Fill = new SolidColorBrush(Colors.Red),
                    Width = 40,
                    Height = 40
                };
            grid.Children.Add(circ);
            grid.Children.Add(backimg);

            MapOverlay vidOverlay = new MapOverlay
            {
                GeoCoordinate = asd,
                Content = grid
            };

            if (removeVidOverlay) vidLayer.Add(vidOverlay);
            else vidOverlays.Add(vidOverlay);
            myMap.Tap -= myMap_TapVid;
        }
        void myMap_TapPoem(object sender, System.Windows.Input.GestureEventArgs e)
        {
            GeoCoordinate asd = this.myMap.ConvertViewportPointToGeoCoordinate(e.GetPosition(this.myMap));

            var grid = new Grid
            {
                Width = 75,
                Height = 75,
                Margin = new System.Windows.Thickness(-25, -25, 0, 0)
            };
            var backimg = new Image
                {
                    Source = new BitmapImage
                    {
                        UriSource = new Uri("/Assets/appbar.draw.pen.png", UriKind.Relative)
                    },
                    Clip = new EllipseGeometry
                    {
                        RadiusX = 28,
                        RadiusY = 28,
                        Center = new System.Windows.Point(37, 37),
                    }
                };
            var circ = new Ellipse
                {
                    Fill = new SolidColorBrush(Colors.Orange),
                    Width = 40,
                    Height = 40
                };
            grid.Children.Add(circ);
            grid.Children.Add(backimg);

            MapOverlay poemOverlay = new MapOverlay
            {
                GeoCoordinate = asd,
                Content = grid
            };

            if (removePoemOverlay) poemLayer.Add(poemOverlay);
            else poemOverlays.Add(poemOverlay);
            
            myMap.Tap -= myMap_TapPoem;
        }
    }
}
