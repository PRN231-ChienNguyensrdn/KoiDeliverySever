import { BrowserRouter } from "react-router-dom";
import Router from "./router";
import { Toaster } from "./components/ui/sonner";

import "./App.css";
import { UserProvider } from "./context";
import { ToastContainer } from "react-toastify";
function App() {
  return (
    <UserProvider>
      <BrowserRouter>
        <Router />
        <Toaster position="top-right" richColors />
        <ToastContainer position="top-right" autoClose={5000} hideProgressBar={false} newestOnTop closeOnClick rtl={false} pauseOnFocusLoss draggable pauseOnHover />
      </BrowserRouter>
    </UserProvider>
  );
}

export default App;
