using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GridMvcPOC.Util
{
    public class GridConfig : ConfigReader
    {
        #region singleton

        private static GridConfig _gridOptions;

        private GridConfig()
        {
            var section = ConfigFile.GetSection("GridParams");
        }

        public static GridConfig GridParams
        {
            get { return _gridOptions ?? (_gridOptions = new GridConfig()); }
        }

        #endregion
        private string _headerStyle;
        public string HeaderStyle
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_headerStyle))
                    return _headerStyle;

                var param = AppParams.SingleOrDefault(x => x.Name == "HeaderStyle");
                if (param == null || string.IsNullOrWhiteSpace(param.Value))
                {
                    _headerStyle = "";
                }
                else
                {
                    _headerStyle = param.Value;
                }
                return _headerStyle;
            }
        }
    }

    public class ParamElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }
    }

    [ConfigurationCollection(typeof(ParamElement))]
    public class ParamElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ParamElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ParamElement)element).Name;
        }
    }

    public class GridParamsSection : ConfigurationSection
    {
        [ConfigurationProperty("release", IsDefaultCollection = true)]
        public ParamElementCollection ReleaseParams
        {
            get { return (ParamElementCollection)this["release"]; }
            set { this["release"] = value; }
        }

        [ConfigurationProperty("debug", IsDefaultCollection = true)]
        public ParamElementCollection DebugParams
        {
            get { return (ParamElementCollection)this["debug"]; }
            set { this["debug"] = value; }
        }
    }

    public enum ApplicationMode
    {
        Release,
        Debug
    }

}