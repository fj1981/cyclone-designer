using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFFmpeg.thriftImpl;
using Newtonsoft.Json;

namespace FrameClient
{
  public delegate void NotifyUpdateHoverRectHandler(string rc);
  public delegate void NotifyEnanleAddFlowItemHandler();

  internal class CellPhoneProxy : Common.Singleton<CellPhoneProxy>
  {
    const int stPort = 11111;
    public NotifyUpdateHoverRectHandler notifyUpdateHoverRect;
    public NotifyEnanleAddFlowItemHandler notifyEnanleAddFlowItem;

    public bool NewProject(string prjName)
    {
      return ScreenClient.Start(stPort, prjName);
    }

    public bool RunProject(string prjName)
    {
      return ScreenClient.ExcuteProcess(stPort, prjName);
    }

    public bool BeginAddFlowItem()
    {
      return ScreenClient.Dump(stPort);
    }

    public string RemoveProcess(int lineNumber)
    {
      return ScreenClient.RemoveProcess(stPort,$"{lineNumber}");
    }


    public bool EndAddFlowItem(string obj)
    {
      if(obj == null || obj.Length == 0)
      {
        return false;
      }

      var data = JsonConvert.DeserializeObject<NewFlowDataOrg>(obj);
      string ret;
      string inputParam = null;
      if(data.param.Length != 0)
      {
        NewValData newVal = new NewValData();
        newVal.lineNumber = -1;
        newVal.value = data.param;
        var newValParam = JsonConvert.SerializeObject(newVal);
        ret = ScreenClient.AddVar(stPort, newValParam);
        if(ret.Length == 0)
        {
          return false;
        }
        var ret2 = JsonConvert.DeserializeObject<NewValRet>(ret);
        if(null == ret2 || ret2.result.code != 1)
        {
          return false;
        }
        inputParam = JsonConvert.SerializeObject(ret2.config);
      }

      NewFlowData newFlowData = new NewFlowData();
      if(inputParam != null)
      {
        newFlowData.@params = new List<string>();
        newFlowData.@params.Add(inputParam);
      }
      var newImageName = ImgMgr.Get().NewSaveImage();
      if(null == newImageName)
      {
        return false;
      }
      newFlowData.point = GlobDef.GetDevPoint(data.pt);
      newFlowData.type = data.type;
      newFlowData.preLineNumber = data.preLineNumber;
      newFlowData.serial = newImageName;

      string flowItem = JsonConvert.SerializeObject(newFlowData);
      string addFlowItemRetStr = ScreenClient.AddProcess(stPort, flowItem); 
      if(addFlowItemRetStr.Length == 0)
      {
        return false;
      }
      notifyEnanleAddFlowItem?.Invoke();
      return true;
      
    }

    public bool MouseMove(string obj)
    {
      var pt = JsonConvert.DeserializeObject<Point>(obj);
      pt = GlobDef.GetDevPoint(pt);
      var ret = ScreenClient.sendPoint(stPort, pt.x, pt.y);
      notifyUpdateHoverRect?.Invoke(ret);
      return true;
    }
  }
}
