import React from 'react';

const LoadingComponent: React.FC<{ inverted?: boolean; content?: string }> = ({
  inverted = true,
  content
}) => {
  return (
    // @*---loader---*@
    <div className="loader">
        <div className="loader-inner">
            <div className="loader-line-wrap">
                <div className="loader-line"></div>
            </div>
            <div className="loader-line-wrap">
                <div className="loader-line"></div>
            </div>
            <div className="loader-line-wrap">
                <div className="loader-line"></div>
            </div>
            <div className="loader-line-wrap">
                <div className="loader-line"></div>
            </div>
            <div className="loader-line-wrap">
                <div className="loader-line"></div>
            </div>
        </div>
    </div>
    // @*---endloader---*@
  );
};

export default LoadingComponent;
