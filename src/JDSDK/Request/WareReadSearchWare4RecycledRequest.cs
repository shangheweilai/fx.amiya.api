using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class WareReadSearchWare4RecycledRequest : JdRequestBase<WareReadSearchWare4RecycledResponse>
    {
                                                                                                                                                                                                                                                                                                                                                                          public  		string
              wareId
 {get; set;}
                                                          
                                                                                           public  		string
              searchKey
 {get; set;}
                                                          
                                                                                      public  		string
              searchField
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              categoryId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              shopCategoryIdLevel1
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              shopCategoryIdLevel2
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              templateId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              promiseId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              brandId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  featureKey {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  featureValue {get; set; }
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 		public  		string
  wareStatusValue {get; set; }
                                                                                                                                                                                                public  		string
              itemNum
 {get; set;}
                                                          
                                                          public  		string
              barCode
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              colType
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startCreatedTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endCreatedTime
 {get; set;}
                                                          
                                                          public  		string
              startJdPrice
 {get; set;}
                                                          
                                                          public  		string
              endJdPrice
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startOnlineTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endOnlineTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startModifiedTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endModifiedTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startOfflineTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endOfflineTime
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              startStockNum
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              endStockNum
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  orderField {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  orderType {get; set; }
                                                                                                                                                                                                public  		Nullable<int>
              pageNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              transportId
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              claim
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              groupId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              multiCategoryId
 {get; set;}
                                                          
                                                                                                                                                                                                                                                                                                                                                            		public  		string
  warePropKey {get; set; }
                                                                                                                                                                                                                                                                                                                         		public  		string
  warePropValue {get; set; }
                                                                                                                                                                                                                                                             public  		string
              field
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.ware.read.searchWare4Recycled";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                        parameters.Add("wareId", this.            wareId
);
                                                                                                                                                        parameters.Add("searchKey", this.            searchKey
);
                                                                                                        parameters.Add("searchField", this.            searchField
);
                                                                                                        parameters.Add("categoryId", this.            categoryId
);
                                                                                                        parameters.Add("shopCategoryIdLevel1", this.            shopCategoryIdLevel1
);
                                                                                                        parameters.Add("shopCategoryIdLevel2", this.            shopCategoryIdLevel2
);
                                                                                                        parameters.Add("templateId", this.            templateId
);
                                                                                                        parameters.Add("promiseId", this.            promiseId
);
                                                                                                        parameters.Add("brandId", this.            brandId
);
                                                                                                                                                                                        parameters.Add("featureKey", this.            featureKey
);
                                                                                                        parameters.Add("featureValue", this.            featureValue
);
                                                                                                                                                                                                parameters.Add("wareStatusValue", this.            wareStatusValue
);
                                                                                                                                parameters.Add("itemNum", this.            itemNum
);
                                                                                                        parameters.Add("barCode", this.            barCode
);
                                                                                                        parameters.Add("colType", this.            colType
);
                                                                                                        parameters.Add("startCreatedTime", this.            startCreatedTime
);
                                                                                                        parameters.Add("endCreatedTime", this.            endCreatedTime
);
                                                                                                        parameters.Add("startJdPrice", this.            startJdPrice
);
                                                                                                        parameters.Add("endJdPrice", this.            endJdPrice
);
                                                                                                        parameters.Add("startOnlineTime", this.            startOnlineTime
);
                                                                                                        parameters.Add("endOnlineTime", this.            endOnlineTime
);
                                                                                                        parameters.Add("startModifiedTime", this.            startModifiedTime
);
                                                                                                        parameters.Add("endModifiedTime", this.            endModifiedTime
);
                                                                                                        parameters.Add("startOfflineTime", this.            startOfflineTime
);
                                                                                                        parameters.Add("endOfflineTime", this.            endOfflineTime
);
                                                                                                        parameters.Add("startStockNum", this.            startStockNum
);
                                                                                                        parameters.Add("endStockNum", this.            endStockNum
);
                                                                                                                                                                                        parameters.Add("orderField", this.            orderField
);
                                                                                                        parameters.Add("orderType", this.            orderType
);
                                                                                                                                                        parameters.Add("pageNo", this.            pageNo
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("transportId", this.            transportId
);
                                                                                                        parameters.Add("claim", this.            claim
);
                                                                                                        parameters.Add("groupId", this.            groupId
);
                                                                                                        parameters.Add("multiCategoryId", this.            multiCategoryId
);
                                                                                                                                                                                        parameters.Add("warePropKey", this.            warePropKey
);
                                                                                                        parameters.Add("warePropValue", this.            warePropValue
);
                                                                                                                                                                                parameters.Add("field", this.            field
);
                                                    }
    }
}





        
 

