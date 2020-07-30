import React from 'react';

const LoadingComponent: React.FC<{ inverted?: boolean; content?: string }> = ({
  inverted = true,
  content
}) => {
  return (
    <div>loading ...</div>
  );
};

export default LoadingComponent;
