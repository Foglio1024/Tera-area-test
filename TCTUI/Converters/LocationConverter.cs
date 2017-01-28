﻿using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Xml.Linq;

namespace Tera.Converters
{
    public class LocationIdToName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var id = (uint)value;
            string locationName = "Unknown location";

            XElement s = TCTData.TCTDatabase.NewWorldMapData.Descendants("Section").Where(x => (string)x.Attribute("id") == id.ToString()).FirstOrDefault();
            if (s != null)
            {
                XElement t = TCTData.TCTDatabase.StrSheet_Region.Descendants().Where(x => (string)x.Attribute("id") == s.Attribute("nameId").Value).FirstOrDefault();

                if (t != null)
                {
                    locationName =  t.Attribute("string").Value;
                }
            }
            return locationName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}