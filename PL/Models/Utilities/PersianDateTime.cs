using System;

namespace loppinja.Models.Utilities
{
    public static class MRPersianDateTime
    {
        public static DateTime ToDateTime(DateTime dateTime)
        {
            int sal = dateTime.Year;
            int mah = dateTime.Month;
            int roz = dateTime.Day;

            int s=sal -1;
            int m=mah -1;
            int r=roz;
            
            if( m<=6 )
            {
                r=(int)((s*365.25)+(m*31)+r+.25);
            } 
            else{
                r=(int)((s*365.25)+(m-6)*30+186 + r+.25);
            } 

            r=r+226899;
            
            int sa= (int)((r/365.25)+1);
            int ss=(int)(r/365.25);
            ss=(int)(ss*365.25);

            r=r-ss;
            int ma = 0,ro = 0;
            
            if( sa%4== 0) {
                if(r==0) {
                    sa=sa-1;
                    ma=12;
                    ro=31;
                }
                
                if(r<=31){
                    ma=1;
                    ro=r;
                } 
                else if(r<=60){
                    ma=2;
                    ro=r-31;
                } 
                else if(r<=91){
                    ma=3;
                    ro=r-60;
                } 
                else if(r<=121){
                    ma=4;
                    ro=r-91;
                } 
                else if(r<=152){
                    ma=5;
                    ro=r-121;
                } 
                else if(r<=182){
                    ma=6;
                    ro=r-152;
                } 
                else if(r<=213){
                    ma=7;
                    ro=r-182;
                }   
                else if(r<=244){
                    ma=8;
                    ro=r-213;
                }   
                else if(r<=274){
                    ma=9;
                    ro=r-244;
                }   
                else if(r<=305){
                    ma=10;
                    ro=r-274;
                } 
                else if(r<=335){
                    ma=11;
                    ro=r-305;
                } 
                else if(r<=366){
                    ma=12;
                    ro=r-335;
                } 
            }
            
            else{
            
            if(r==0){
                sa=sa-1; ma=12; ro=31;
            } 
            else if(r<=31){
                ma=1;
                ro=r;
            } 
            else if(r<=59){
                ma=2;
                ro=r-31;
            } 
            else if(r<=90){
                ma=3;
                ro=r-59;
            } 
            else if(r<=120){
                ma=4;
                ro=r-90;
            } 
            else if(r<=151){
                ma=5;
                ro=r-120;
            } 
            else if(r<=181){
                ma=6;
                ro=r-151;
            } 
            else if(r<=212){
                ma=7;
                ro=r-181;
            } 
            else if(r<=243){
                ma=8;
                ro=r-212;
            }   
            else if(r<=273){
                ma=9; ro=r-243;
            } 
            else if(r<=304){
                ma=10; ro=r-273;
            } 
            else if(r<=334){
                ma=11; ro=r-304;
            } 
            else if(r<366){
                ma=12; ro=r-334;
            } 
            else if (r==366) {
                sa=sa+1; ma=1; ro=1;
            }   
            
            }
            return new DateTime(sa, ma, ro);
        }

        public static DateTime ToPersianDateTime(DateTime dateTime)
        {
            int sal = dateTime.Year;
            int mah = dateTime.Month;
            int roz = dateTime.Day;
            
            int s=sal-1;
            int m=mah-1;
            int r = 0;

            if (sal%4==0){

                r = m switch  
                {  
                    0 => (int)(s*365.25)+roz,
                    1 => (int)(s*365.25)+31+roz,
                    2 => (int)(s*365.25)+31+29+roz,
                    3 => (int)(s*365.25)+31+29+31+roz,
                    4 => (int)(s*365.25)+31+29+31+30+roz,
                    5 => (int)(s*365.25)+31+29+31+30+31+roz,
                    6 => (int)(s*365.25)+31+29+31+30+31+30+roz,
                    7 => (int)(s*365.25)+31+29+31+30+31+30+31+roz,
                    8 => (int)(s*365.25)+31+29+31+30+31+30+31+31+roz,
                    9 => (int)(s*365.25)+31+29+31+30+31+30+31+31+30+roz,
                    10 => (int)(s*365.25)+31+29+31+30+31+30+31+31+30+31+roz,
                    11 => (int)(s*365.25)+31+29+31+30+31+30+31+31+30+31+30+roz,
                    _ => 0
                };
            }
            else {
                r = m switch
                {
                    0 => (int)(s*365.25)+roz,
                    1 => (int)(s*365.25)+31+roz,
                    2 => (int)(s*365.25)+31+28+roz,
                    3 => (int)(s*365.25)+31+28+31+roz,
                    4 => (int)(s*365.25)+31+28+31+30+roz,
                    5 => (int)(s*365.25)+31+28+31+30+31+roz,
                    6 => (int)(s*365.25)+31+28+31+30+31+30+roz,
                    7 => (int)(s*365.25)+31+28+31+30+31+30+31+roz,
                    8 => (int)(s*365.25)+31+28+31+30+31+30+31+31+roz,
                    9 => (int)(s*365.25)+31+28+31+30+31+30+31+31+30+roz,
                    10 => (int)(s*365.25)+31+28+31+30+31+30+31+31+30+31+roz,
                    11 => (int)(s*365.25)+31+28+31+30+31+30+31+31+30+31+30+roz,
                    _ => 0
                };                
            }
            
            r = r-226899;

            int sa= (int)(r/365.25)+1 ;
            int ss= (int) (r/365.25);
            r = (int)(r- (ss*365.25)+.25);
            
            int ma = 0;
            int ro = 0;

            if (sa%4==3) {
                r=r+1;
            }
            
            if(r>336) {
                ma=12;
                ro=r-336;
            }
            
            else if(r>306){
                ma=11;ro=r-306;
            } 
            else  if(r>276)
            {
                ma=10;ro=r-276;
            } 
            else  if(r>246)
            {
                ma=9;ro=r-246;
            } 
            else  if(r>216)
            {
                ma=8; ro=r-216;
            } 
            else  if(r>186)
            {
                ma=7; ro=r-186;
            } 
            else  if(r>155){
                ma=6; ro=r-155;
            } 
            else  if(r>124)
            {
                ma=5; ro=r-124;
            } 
            else  if(r>93)
            {
                ma=4; ro=r-93;
            } 
            else  if(r>62){
                ma=3; ro=r-62;
            } 
            else  if(r>31){
                ma=2; ro=r-31;
            } 
            else  if(r>0)
            {
                ma=1; ro=r;
            } 
            else if(r==0)
            {
                if(sa%4!=0)
                {
                    sa=sa-1; ma=12; ro=29;
                }
                else 
                {
                    sa=sa-1;ma=12;ro=30;
                }
            }
            

            return new DateTime(sa, ma, ro);
        }
    }


}
