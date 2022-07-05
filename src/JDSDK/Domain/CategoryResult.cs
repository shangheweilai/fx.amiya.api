using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Jd.Api.Domain;
namespace Jd.Api.Domain
{

[Serializable]
public class CategoryResult:JdObject{
      [JsonProperty("success")]
public 					bool

             success
 { get; set; }
      [JsonProperty("errorCode")]
public 				string

             errorCode
 { get; set; }
      [JsonProperty("list")]
public 				List<string>

             list
 { get; set; }
      [JsonProperty("errorMsg")]
public 				string

             errorMsg
 { get; set; }
	}
}