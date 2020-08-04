import React, { useState, useContext,useEffect } from 'react'
import  Cookies from 'js-cookie'



const LogOut = () => {

    //دیگر لازم نیست  یوزر را نال کنم چون توکن پاک  شد وصفحه رفرش مسشه
    useEffect(() => {
       Cookies.remove('jwt');
       localStorage.removeItem('jwt')
       window.location.href='/'
    }, [])


    return (
        <>
                     
        </>
    )
}


export default LogOut 