import { BrowserRouter } from "react-router-dom";
import Router from "./router";
import { Toaster } from "./components/ui/sonner";

import "./App.css";
import { UserProvider } from "./context";
function App() {
  return (
    <UserProvider>
      <BrowserRouter>
        <Router />
        <Toaster position="top-right" richColors />
      </BrowserRouter>
    </UserProvider>
  );
}

export default App;
