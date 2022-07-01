using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class LasSpareZerostockDetectionPushRequest : JdRequestBase<LasSpareZerostockDetectionPushResponse>
    {
                                                                                                                                              public  		string
                                                                                      ordNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      afsNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                                                                                      afsSerTasNo
 {get; set;}
                                                                                                                                                                                  
                                                          public  		string
                                                                                      engNo
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      engN
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      engMp
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      gooSku
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      actT
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      gooN
 {get; set;}
                                                                                                                                  
                                                          public  		Nullable<int>
                                                                                      detRs
 {get; set;}
                                                                                                                                  
                                                          public  	    Nullable<bool>
                                                                                      isInv
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      gooSn
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                                                      notRefRea
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                      refRea
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                      deaTyp
 {get; set;}
                                                                                                                                  
                                                          public  		string
                                                                                                                      gooPacN
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                                                      gooExtN
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                                                      gooFunN
 {get; set;}
                                                                                                                                                          
                                                          public  		string
                                                                                      attDesc
 {get; set;}
                                                                                                                                  
                                                          public  	    Nullable<bool>
                                                                                                                      isBroScr
 {get; set;}
                                                                                                                                                          
                                             public override string ApiName
            {
                get{return "jingdong.las.spare.zerostock.detection.push";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("ord_no", this.                                                                                    ordNo
);
                                                                                                        parameters.Add("afs_no", this.                                                                                    afsNo
);
                                                                                                        parameters.Add("afs_ser_tas_no", this.                                                                                                                                                    afsSerTasNo
);
                                                                                                        parameters.Add("eng_no", this.                                                                                    engNo
);
                                                                                                        parameters.Add("eng_n", this.                                                                                    engN
);
                                                                                                        parameters.Add("eng_mp", this.                                                                                    engMp
);
                                                                                                        parameters.Add("goo_sku", this.                                                                                    gooSku
);
                                                                                                        parameters.Add("act_t", this.                                                                                    actT
);
                                                                                                        parameters.Add("goo_n", this.                                                                                    gooN
);
                                                                                                        parameters.Add("det_rs", this.                                                                                    detRs
);
                                                                                                        parameters.Add("is_inv", this.                                                                                    isInv
);
                                                                                                        parameters.Add("goo_sn", this.                                                                                    gooSn
);
                                                                                                        parameters.Add("not_ref_rea", this.                                                                                                                    notRefRea
);
                                                                                                        parameters.Add("ref_rea", this.                                                                                    refRea
);
                                                                                                        parameters.Add("dea_typ", this.                                                                                    deaTyp
);
                                                                                                        parameters.Add("goo_pac_n", this.                                                                                                                    gooPacN
);
                                                                                                        parameters.Add("goo_ext_n", this.                                                                                                                    gooExtN
);
                                                                                                        parameters.Add("goo_fun_n", this.                                                                                                                    gooFunN
);
                                                                                                        parameters.Add("att_desc", this.                                                                                    attDesc
);
                                                                                                        parameters.Add("is_bro_scr", this.                                                                                                                    isBroScr
);
                                                                            }
    }
}





        
 

