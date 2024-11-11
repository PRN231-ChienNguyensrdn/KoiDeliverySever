import React from 'react';
import { Button, Result } from 'antd';
import { Header } from '@/components/Header';
import  Footer  from '@/components/Footer';
import { Link } from 'react-router-dom';

const Unauthor: React.FC = () => (
  
  <>
  <Header/>
  
  <Result
    status="403"
    title="403"
    subTitle="Sorry, you are not authorized to access this page."
    
    extra={<Button type="primary"><Link to="/" >Back Home</Link></Button>}
  />
  <Footer/>
  </>
);

export default Unauthor;