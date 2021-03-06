using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LogisticsPoAddRequest : JdRequestBase<LogisticsPoAddResponse>
    {
                                                                                                                                              public  		string
                                                                                                                      channelsSellerNo
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                      poNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      warehouseNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      expectDate
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      supplierName
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      supplierNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
              approver
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     		public  		string
  goodsNo {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  expectedQty {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  goodsStatus {get; set; }
                                                                                                                                                                                   public override string ApiName
            {
                get{return "jingdong.logistics.po.add";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("channels_seller_no", this.                                                                                                                    channelsSellerNo
);
                                                                                                        parameters.Add("po_no", this.                                                                                    poNo
);
                                                                                                        parameters.Add("warehouse_no", this.                                                                                    warehouseNo
);
                                                                                                        parameters.Add("expect_date", this.                                                                                    expectDate
);
                                                                                                        parameters.Add("supplier_name", this.                                                                                    supplierName
);
                                                                                                        parameters.Add("supplier_no", this.                                                                                    supplierNo
);
                                                                                                        parameters.Add("approver", this.            approver
);
                                                                                                                                                                                                                parameters.Add("goods_no", this.                                                                                    goodsNo
);
                                                                                                        parameters.Add("expected_qty", this.                                                                                    expectedQty
);
                                                                                                        parameters.Add("goods_status", this.                                                                                    goodsStatus
);
                                                                                                                                                    }
    }
}





        
 

