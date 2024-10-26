import { NavLink } from 'react-router-dom';

const LogoComponent = () => {
  return (
    <NavLink to={'/'} className={'flex justify-center items-center '}>
    <p className='text-3xl font-semibold'>KOI DELI</p>
    </NavLink>
  );
};

export default LogoComponent;
