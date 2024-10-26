import React from 'react';
import { cn } from '@/lib/utils';
import { Loader2 } from 'lucide-react';

interface LoadingComponentProps {
  className?: string | undefined;
}

const LoadingComponent: React.FC<LoadingComponentProps> = ({ className }) => {
  return <Loader2 className={cn('animate-spin', className)} />;
};

export default LoadingComponent;
