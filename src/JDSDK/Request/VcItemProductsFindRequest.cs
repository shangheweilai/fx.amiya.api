using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class VcItemProductsFindRequest : JdRequestBase<VcItemProductsFindResponse>
    {
                                                                                                                                                                               public  		string
                                                                                      wareId
 {get; set;}
                                                                                                                                  
                                                          public  		string
              name
 {get; set;}
                                                          
                                                          public  		Nullable<int>
                                                                                      brandId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      categoryId
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      saleState
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<DateTime>
                                                                                                                      beginModifyTime
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<DateTime>
                                                                                                                      endModifyTime
 {get; set;}
                                                                                                                                                          
                                                          public  		Nullable<int>
              offset
 {get; set;}
                                                          
                                                          public  		Nullable<int>
                                                                                      pageSize
 {get; set;}
                                                                                                                                  
                                             public override string ApiName
            {
                get{return "jingdong.vc.item.products.find";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("ware_id", this.                                                                                    wareId
);
                                                                                                        parameters.Add("name", this.            name
);
                                                                                                        parameters.Add("brand_id", this.                                                                                    brandId
);
                                                                                                        parameters.Add("category_id", this.                                                                                    categoryId
);
                                                                                                        parameters.Add("sale_state", this.                                                                                    saleState
);
                                                                                                        parameters.Add("begin_modify_time", this.                                                                                                                    beginModifyTime
);
                                                                                                        parameters.Add("end_modify_time", this.                                                                                                                    endModifyTime
);
                                                                                                        parameters.Add("offset", this.            offset
);
                                                                                                        parameters.Add("page_size", this.                                                                                    pageSize
);
                                                                            }
    }
}





        
 

