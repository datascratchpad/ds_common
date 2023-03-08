using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ds_common
{






    public static class Utilities
    {


        public const string VisualisationMethodKeyword = "visualisation_method";
        public const string VisualisationType_Text = "text";
        public const string VisualisationType_Grid = "grid";
        public const string VisualisationType_Graph = "graph";



        public static string GetConfigParameter(string ParameterName, ref OActivityState AState)
        {
            string ret = null;
            if (string.IsNullOrEmpty(ParameterName)) return ret;
            if (AState == null) return ret;
            if (AState.ConfigObj == null) return ret;
            if (AState.ConfigObj.Count == 0) return ret;


            for (int i = 0; i < AState.ConfigObj.Count; i++)
            {
                if (string.Equals(AState.ConfigObj[i].KeyName, ParameterName, StringComparison.OrdinalIgnoreCase))
                {
                    ret = AState.ConfigObj[i].ValueStr;
                    break;
                }
            }

            return ret;
        }



    }





    public class OCommandOutput
    {
        public List<string> Information;
        public List<object> PrimaryOutput;
        public List<object> VisualOutput;
    }


    public class OActivityState
    {
        public string ActivityName;
        public List<OStrKeyValuePair> ConfigObj;
        public List<object> IntermediateObj;
        public OCommandOutput OutputObj;
        public bool HasInitialisationCompleted;
        public bool Started;
        public DateTime StartedDT;
        public bool DataExtractComplete;
        public DateTime DataExtractCompleteDT;
        public bool Completed;
        public DateTime CompletedDT;
        public List<string> SourceOriginalFieldHeaders;
        public List<string> OutputMessagesToUser;
        public ofr ofr;  // Object Return Function - the outcome of the process
        public bool EarlyTermination = false;  // Set and used by the program: when row sampling of explicit rows is used, and the program determines that all of the requested rows have been obtained. This allows the file reading process to terminate early, rather than continuing reading the file for no reason.
        public long ProcessedRowsCount = 0;
        public bool AnalysisWindowUsed = false;
    }



    public class OStrKeyValuePair
    {
        public string KeyName;
        public string ValueStr;
    }



    public class OIncrementalDataObject
    {
        public object IDO;
        public List<OFieldIDPair> LFieldsNameID;  // The ID in here is the original ID of the field
        public long ProcessedRowID;
        public bool SourceIsText;
    }


    public class OFieldIDPair
    {
        public string FieldName = String.Empty;
        public int ID = 0;
    }



    // Class Object Function Return
    public class ofr
    {
        public RefReturnValues PrimaryReturnValue;
        public List<RefReturnValues> AdditionalReturnValues;
        public string ErrorMessage;
        public string ErrorDetails;
        public string ProcessingPoint;
        public string AdditionalInfo;
        public string FunctionName;
        public DateTime DT;
        public ofr ChildReturnObject;
    }


    public enum RefReturnValues : int
    {
        Indeterminate = 0,
        Success = 1,
        ConditionalSuccess = 2,
        InvalidInputParameters = -1,
        ErrorWithinFunction = -2,
        ErrorInCodeOutsideOfThisFunction = -3,
        ErrorInExternalFile = -4,
        ErrorInExternalDB = -5,
        ErrorInExternalAPI = -6,
        ErrorInExternalObject = -7,
        OtherError = -8,
        ExpectedResponseNotFound = -9,
        InvalidCredentials = -10,
        FileNotFound = -11,
        InvalidConfigurationSpecification = -12,
        CancelledByUser = -13
    }



}
