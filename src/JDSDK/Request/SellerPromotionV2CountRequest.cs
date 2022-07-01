using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class SellerPromotionV2CountRequest : JdRequestBase<SellerPromotionV2CountResponse>
    {
                                                                                                                                                                                                                public  		string
              ip
 {get; set;}
                                                          
                                                          public  		string
              port
 {get; set;}
                                                          
                                                                                                                                                                                        public  		Nullable<long>
                                                                                      promoId
 {get; set;}
                                                                                                                                  
                                                                                           public  		string
              name
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              type
 {get; set;}
                                                          
                                                          public  		Nullable<int>
                                                                                      favorMode
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      beginTime
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      endTime
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      promoStatus
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                      wareId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<long>
                                                                                      skuId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      srcType
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.seller.promotion.v2.count";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("ip", this.            ip
);
                                                                                                        parameters.Add("port", this.            port
);
                                                                                                                                                                                                                        parameters.Add("promo_id", this.                                                                                    promoId
);
                                                                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                        parameters.Add("favor_mode", this.                                                                                    favorMode
);
                                                                                                        parameters.Add("begin_time", this.                                                                                    beginTime
);
                                                                                                        parameters.Add("end_time", this.                                                                                    endTime
);
                                                                                                        parameters.Add("promo_status", this.                                                                                    promoStatus
);
                                                                                                        parameters.Add("ware_id", this.                                                                                    wareId
);
                                                                                                        parameters.Add("sku_id", this.                                                                                    skuId
);
                                                                                                        parameters.Add("src_type", this.                                                                                    srcType
);
                                                                            }
    }
}





        
 

