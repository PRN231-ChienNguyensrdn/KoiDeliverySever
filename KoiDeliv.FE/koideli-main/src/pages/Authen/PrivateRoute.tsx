// PrivateRoute.tsx
import React from 'react';
import { Navigate } from 'react-router-dom';
import { jwtDecode } from "jwt-decode";


interface PrivateRouteProps {
  allowedRoles: string[];
  element: JSX.Element;
}
interface CustomJwtPayload {
  UserId: string;
  UserName: string;
  Email: string;
  Role: string; 
  exp: number;
  iss: string;
  aud: string;
}


const PrivateRoute: React.FC<PrivateRouteProps> = ({ allowedRoles, element }) => {

  const user = JSON.parse(localStorage.getItem("authToken") || '{}');
  console.log("what is this ",user)
  const userData = jwtDecode<CustomJwtPayload>(user.accessToken);

  const isAuthenticated = !!userData && !!userData.Role;
  const userRole = userData.Role || '';

  // Kiểm tra xem người dùng có quyền truy cập không
  if (!isAuthenticated) {
    return <Navigate to="/login" replace />;
  }

  // Kiểm tra nếu vai trò của người dùng không nằm trong allowedRoles
  if (!allowedRoles.includes(userRole)) {
    return <Navigate to="/unauthorized" replace />;
  }

  return element;
};

export default PrivateRoute;
