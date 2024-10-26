import React, { createContext, useContext, useReducer, Dispatch } from "react";

// Khai báo kiểu dữ liệu cho state và action
interface UserState {
  data: { name: string; email: string } | null;
  isAdmin: boolean;
}

type UserAction =
  | { type: "UPDATE_USER"; payload: { name: string; email: string } | null }
  | { type: "TOGGLE_ADMIN" };

// Khởi tạo state ban đầu
const initialState: UserState = {
  data: null,
  isAdmin: false,
};

// Tạo context với giá trị khởi tạo là null (để dễ kiểm tra)
const UserContext = createContext<{
  state: UserState;
  dispatch: Dispatch<UserAction>;
} | null>(null);

// Định nghĩa reducer để quản lý các hành động
const userReducer = (state: UserState, action: UserAction): UserState => {
  switch (action.type) {
    case "UPDATE_USER":
      return {
        ...state,
        data: action.payload,
      };
    case "TOGGLE_ADMIN":
      return {
        ...state,
        isAdmin: !state.isAdmin,
      };
    default:
      return state;
  }
};

// Tạo component Provider để cung cấp state và dispatch cho các component con
export const UserProvider = ({ children }: { children: React.ReactNode }) => {
  const [state, dispatch] = useReducer(userReducer, initialState);

  return (
    <UserContext.Provider value={{ state, dispatch }}>
      {children}
    </UserContext.Provider>
  );
};

// Custom hook để sử dụng context dễ dàng
export const useUser = () => {
  const context = useContext(UserContext);
  if (!context) {
    throw new Error("useUser phải được sử dụng trong UserProvider");
  }
  return context;
};
