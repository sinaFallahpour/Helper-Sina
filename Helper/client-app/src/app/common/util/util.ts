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