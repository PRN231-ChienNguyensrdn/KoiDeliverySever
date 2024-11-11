// AuthContext.tsx
import React, { createContext, useState, useContext, ReactNode, useEffect } from 'react';
import { jwtDecode } from "jwt-decode";

// Định nghĩa kiểu dữ liệu cho context
interface AuthContextType {
  userRole: string | null;
  setRole: (role: string) => void;
}

// Tạo context để chia sẻ quyền truy cập
const AuthContext = createContext<AuthContextType | undefined>(undefined);

// Hook để sử dụng AuthContext
export const useAuth = (): AuthContextType => {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error("useAuth must be used within an AuthProvider");
  }
  return context;
};

// Cung cấp quyền truy cập cho toàn bộ ứng dụng
interface AuthProviderProps {
  children: ReactNode;
}

export const AuthProvider: React.FC<AuthProviderProps> = ({ children }) => {
  const [userRole, setUserRole] = useState<string | null>(null);

  // Giải mã token để lấy thông tin vai trò khi ứng dụng khởi động
  useEffect(() => {
    const token = localStorage.getItem('authToken');
    if (token) {
      const decoded: any = jwtDecode(token);
      setUserRole(decoded.role);
    }
  }, []);

  const setRole = (role: string) => {
    setUserRole(role);
  };

  return (
    <AuthContext.Provider value={{ userRole, setRole }}>
      {children}
    </AuthContext.Provider>
  );
};
