# Devlink
# Devlink is a .NET managed library wrapper for working with the Avaya IP 500 Central

# Implementation









DevlinkHelper devlink = new DevlinkHelper();

devlink.PbxConnect($"{avaya central ip address}", $"{avaya central password}");
devlink.CallLogEventType = CallLogType.Advavanced;

  //Delegate Method 
  devlink.OnCallLogEventS += OnCallLogEventS;
  //Delegate Method 
  devlink.OnCallLogEventD += OnCallLogEventD;
  //Delegate Method 
  devlink.OnCallLogEventA += OnCallLogEventA;
  //Delegate Method 
  devlink.OnConnectionStatus += OnConnectionStatus;
 




     private void OnCallLogEventD(object source, CallLog_D_Parameter e)
        {
            try
            {               
             // Receiving Call Log 
            }
            catch (Exception ex)
            {                
            }
     }
     
    private void OnCallLogEventD(object source, CallLog_D_Parameter e)
        {
            try
            {               
             // Receiving Call Log 
            }
            catch (Exception ex)
            {                
            }
     }
     

    private void OnCallLogEventA(object source, CallLog_A_Parameter e)
        {
            try
            {               
                    // Receiving Call Log
            }
            catch (Exception ex)
            {                
            }
     }


     
      private void OnConnectionStatus(object source, Connection_Status_Paramenter e)
       {
           try
          {               
            // Receiving Connection Status Log
          }
         catch (Exception ex)
        {                
        }
     }
