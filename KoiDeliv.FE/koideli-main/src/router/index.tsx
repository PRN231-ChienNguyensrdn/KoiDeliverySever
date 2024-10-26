import { Outlet, useRoutes } from "react-router-dom";
import type { RouteObject } from "react-router-dom";
import { paths } from "@/constants";
import AdminLayout from "@/layout/AdminLayout";
import PostItemPage from "@/pages/PostItemPage";
import Dashboard from "@/pages/DashBoard.tsx";
import HomePage from "@/pages/HomePage.tsx";
import MainLayout from "@/layout/MainLayout";
import ServicePage from "@/pages/ServicePage";
import Login from "@/pages/Login";
import OrderPage from "@/pages/OrderPage";
import StaffPage from "@/pages/StaffPage";
import NotFoundPage from "@/pages/NotFoundPage";
import PostManagementPage from "@/pages/PostManagementPage";

const lazyRoutes: RouteObject[] = [
  {
    path: "/",
    children: [
      {
        path: "admin",
        children: [
          {
            path: "",
            element: (
              <AdminLayout>
                <Outlet />
              </AdminLayout>
            ),
            children: [
              {
                path: paths.dashboard,
                element: <Dashboard />,
              },
              {
                path: paths.ordersManagement,
                element: (
                  <>
                    <PostManagementPage />
                    <Outlet />
                  </>
                ),
                children: [
                  {
                    path: ":id",
                    element: <PostItemPage />,
                  },
                ],
              },
            ],
          },
        ],
      },
      {
        path: "staff",
        element: <StaffPage />,
      },
      {
        path: "",
        children: [
          {
            path: "",
            element: (
              <MainLayout>
                <Outlet />
              </MainLayout>
            ),
            children: [
              {
                path: "",
                element: <HomePage />,
              },
              {
                path: "service",
                element: <ServicePage />,
              },
              {
                path: "login",
                element: <Login />,
              },
              {
                path: "order",
                element: <OrderPage />,
              },
            ],
          },
        ],
      },
      {
        element: <NotFoundPage />,
        path: "*",
      },
    ],
  },
];

const Router = () => {
  const contents = useRoutes(lazyRoutes);
  return <>{contents}</>;
};

export default Router;
