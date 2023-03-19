namespace BTH1303.Models
{
    public class PTB2
    {
        public string Giaiphuongtrinh(string hesoA, string hesoB, string hesoC)
        {
        double delta, a=0, b=0, c=0;
        double x1, x2;
        string ketqua;
        if(!string.IsNullOrEmpty(hesoA)) a = Convert.ToDouble(hesoA);
        if(!string.IsNullOrEmpty(hesoB)) b = Convert.ToDouble(hesoB);
        if(!string.IsNullOrEmpty(hesoC)) c = Convert.ToDouble(hesoC);
        if(a == 0) ketqua = "Day khong phai phuong trinh bac 2";
        else 
        {
            delta = Math.Pow(b,2) - 4*a*c;
        if(delta < 0) ketqua = "Phuong trinh vo nghiem";
        else if (delta == 0)
        {
        x1 = (-b)/(2*a);
        ketqua = "Phuong trinh co nghiem kep x = " + x1;
        }
        else
        {
            x1 = (-b + Math.Sqrt(delta))/(2*a);
            x2 = (-b - Math.Sqrt(delta))/(2*a);
            ketqua = "Phuong trinh co 2 nghiem phan biet x1 = " + x1 + ", x2 = " + x2;
        }  
        }
        return ketqua;
        }
    }
}