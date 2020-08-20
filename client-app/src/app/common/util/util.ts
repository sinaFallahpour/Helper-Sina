export const combineDateAndTime = (date: Date, time: Date) => {
    const timeString = time.getHours() + ':' + time.getMinutes() + ':00';

    const year = date.getFullYear();
    const month = date.getMonth() + 1;
    const day = date.getDate();
    const dateString = `${year}-${month}-${day}`;

    return new Date(dateString + ' ' + timeString);
}


//substring latrege strin [...]
export const toShortString = (text:string, count:number) => {
    if (!text) return "";
    if (text.length >= count) return text.substring(0, count) + "[...]";
    else return text;
};



export const getPriceFormat= (price:string) =>
{
    if(!price)
    return null;
    price+= '';
    price= price.replace(',', '');
    let x = price.split('.');
    let y = x[0];
    let z= x.length > 1 ? '.' + x[1] : '';
    let rgx = /(\d+)(\d{3})/;
    while (rgx.test(y))
    y= y.replace(rgx, '$1' + ',' + '$2');
    return y+ z;
}




  
        /// قرار دادن ویرگول بین عدد برای خوانایی
        /// 12345678 => 12,345,678
     
        // export  const getPriceFormats=( price:string)=>
        // {
        //     if (!price)
        //         return null;
        //    let  InPrice:number;
        //     if(int.TryParse(price , out InPrice))
        //         return String.Format("{0:n0}", InPrice);
        //     return null;
        // }