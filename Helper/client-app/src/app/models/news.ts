export interface INews {
    id: string;
    title: string;
    description: string;
    CreateDate:string;
    likesCount:number;
    commentsCount:number;
    seenCount:number
    newsType:NewsType
    articlePhotoAddress?:string;
    videoAddress?:string;

    isLiked:true;
    
}

