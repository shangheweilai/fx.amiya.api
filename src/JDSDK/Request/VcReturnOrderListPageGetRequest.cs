using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcReturnOrderListPageGetRequest : JdRequestBase<VcReturnOrderListPageGetResponse>
    {
                                                                                                                                              public  		Nullable<long>
              returnId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              fromDeliverCenterId
 {get; set;}
                                                          
                                                          public  		string
              returnStates
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              createDateBegin
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              createDateEnd
 {get; set;}
                                                          
                                                                                           public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageIndex
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.vc.return.order.list.page.get";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("returnId", this.            returnId
);
                                                                                                        parameters.Add("fromDeliverCenterId", this.            fromDeliverCenterId
);
                                                                                                        parameters.Add("returnStates", this.            returnStates
);
                                                                                                        parameters.Add("createDateBegin", this.            createDateBegin
);
                                                                                                        parameters.Add("createDateEnd", this.            createDateEnd
);
                                                                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                            }
    }
}





        
 

