import React from 'react'

const MiniLoading = () => {
    return (
        <div className="container">
            <div className="d-block text-center">
                <div className="spinner-grow" role="status">
                    <span className="sr-only">Loading...</span>
                </div>
            </div>
        </div>
    )
}


export default MiniLoading;