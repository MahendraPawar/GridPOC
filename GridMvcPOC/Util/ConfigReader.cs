using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace GridMvcPOC.Util
{
    public class ConfigReader
    {
        private static Configuration _configuration;

        protected static Configuration ConfigFile
        {
            get
            {
                if (_configuration != null) return _configuration;
                _configuration = ReadConfiguration();
                return _configuration;
            }
        }

        private static Configuration ReadConfiguration()
        {
            var appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            if (appPath == null)
                throw new InvalidDataException("Could not get the config path!!!");
            appPath = appPath.Replace("file:\\", "");
            //var currentDomainPath = AppDomain.CurrentDomain.RelativeSearchPath + "\\" + "ColloSys.config";
            var currentDomainPath = appPath + "\\" + "GridMvc.config";
            var fileMap = new ConfigurationFileMap(currentDomainPath); //Path to your config file
            var configuration = ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
            return configuration;
        }

        #region detect mode

        private ApplicationMode _appMode;

        private void DetectMode()
        {
            _appMode = ApplicationMode.Release;
            IsDebugMode();
        }

        [Conditional("DEBUG")]
        private void IsDebugMode()
        {
            _appMode = ApplicationMode.Debug;
        }

        #endregion

        #region read params

        private GridParamsSection _params;

        private GridParamsSection ParamsSection
        {
            get
            {
                if (_params != null) return _params;
                _params = ConfigFile.GetSection("GridParams") as GridParamsSection;
                return _params;
            }
        }

        #endregion

        #region read params

        protected IEnumerable<ParamElement> AppParams;

        private void ReadParams()
        {
            switch (_appMode)
            {
                case ApplicationMode.Release:
                    AppParams = ParamsSection.ReleaseParams.Cast<ParamElement>();
                    break;
                case ApplicationMode.Debug:
                    AppParams = ParamsSection.DebugParams.Cast<ParamElement>();
                    break;
                default:
                    throw new InvalidProgramException("Invalid ColloSys Param in web Config");
            }
        }

        #endregion

        protected ConfigReader()
        {
            DetectMode();
            ReadParams();
        }
    }
}