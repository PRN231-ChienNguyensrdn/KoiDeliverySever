import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { useUser } from "@/context";
import axios from "axios";
import { useState } from "react";
import { jwtDecode } from "jwt-decode";
import { useNavigate } from "react-router-dom";
import { toast } from "sonner";

const Login = () => {
  const navigate = useNavigate();


  const [loginData, setLoginData] = useState({
    email: "",
    password: "",
  });

  const [signupData, setSignupData] = useState({
    fullName: "",
    email: "",
    passwordHash: "",
    role: "Customer", // default role, adjust as necessary
    phoneNumber: "",
    address: "",
  });

  const handleLoginChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setLoginData({ ...loginData, [e.target.id]: e.target.value });
  };
  const handleSignupChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSignupData({ ...signupData, [e.target.id]: e.target.value });
  };


  const registerUser = async () => {
    try {
      const response = await axios.post(
        "http://localhost:7184/api/User",
        signupData,
        {
          headers: {
            "Content-Type": "application/json",
            // Add any additional headers if needed, e.g., Authorization
            // "Authorization": `Bearer ${token}`
          },
        }
      );
      toast.success("User registered successfully!"); // Show success message
      // Additional logic after successful signup, e.g., redirect or update state
    } catch (error) {
      toast.error("Error registering user. Please try again."); // Show error message

      // Handle error, e.g., show an error message to the user
    }
  };

  interface CustomJwtPayload {
    UserId: string;
    UserName: string;
    Email: string;
    Role: string; 
    exp: number;
    iss: string;
    aud: string;
  }

const loginUser = async () => {
    try {
      const response = await axios.post("http://localhost:7184/api/Authorize/Login", null, {
        params: {
          email: loginData.email,
          password: loginData.password,
        },
      });
      console.log("User logged in successfully:", response.data.data.accessTokenToken);
      localStorage.setItem("authToken", JSON.stringify({
        accessToken: response.data.data.accessTokenToken
      }));
      const userData = jwtDecode<CustomJwtPayload>(response.data.data.accessTokenToken);
      if (userData.Role === "Customer") {
        navigate("/");
      } else if (userData.Role === "Admin") {
        navigate("/admin");
      }else if (userData.Role === "Staff") {
        navigate("/staff");
      }
      toast.success("Login successful!"); // Show success message

    } catch (error) {
      toast.error("Invalid credentials or server error."); // Show error message
    }
  };

  return (
    <div className="bg-[#1e8fd0] py-[100px] ">
      <div className="flex flex-col items-center justify-center mx-auto  lg:py-0">
        <Tabs defaultValue="login" className="w-[400px]">
          <TabsList className="grid w-full grid-cols-2 bg-white">
            <TabsTrigger value="login">Login</TabsTrigger>
            <TabsTrigger value="signup">Signup</TabsTrigger>
          </TabsList>
          <TabsContent value="login">
            <Card className="bg-white">
              <CardHeader>
                <CardTitle className="text-black">Login</CardTitle>
                <CardDescription>
                  Sign in and Get lots of Cashback Rewards and Discount
                </CardDescription>
              </CardHeader>
              <CardContent className="space-y-2">
                <div className="space-y-1">
                  <Label className="text-black">
                    Email
                  </Label>
                  <Input
                    id="email"
                    defaultValue=""
                    value={loginData.email}
                    onChange={handleLoginChange}
                    className="bg-white text-black"
                  />
                </div>
                <div className="space-y-1">
                  <Label className="text-black">
                    Password
                  </Label>
                  <Input
                    id="password"
                    type="password"
                    value={loginData.password}
                    onChange={handleLoginChange}
                    className="bg-white text-black"
                  />
                </div>
              </CardContent>
              <CardFooter>
                <Button
                  className="w-full bg-black text-white hover:bg-slate-600"
                  onClick={loginUser}
                >
                  Login
                </Button>
              </CardFooter>
            </Card>
          </TabsContent>
          <TabsContent value="signup">
            <Card className="bg-white">
              <CardHeader>
                <CardTitle className="text-black">
                  Create Filght World Account
                </CardTitle>
                <CardDescription>
                  For security, please sign in to access your information
                </CardDescription>
              </CardHeader>
              <CardContent className="space-y-2">
                <div className="space-y-1">
                  <Label className="text-black">Full Name</Label>
                  <Input id="fullName" value={signupData.fullName} onChange={handleSignupChange} className="bg-white text-black" />
                </div>
                <div className="space-y-1">
                  <Label className="text-black">Email</Label>
                  <Input id="email" value={signupData.email} onChange={handleSignupChange} className="bg-white text-black" />
                </div>
                <div className="space-y-1">
                  <Label className="text-black">Password</Label>
                  <Input id="passwordHash" type="password" value={signupData.passwordHash} onChange={handleSignupChange} className="bg-white text-black" />
                </div>
                <div className="space-y-1">
                  <Label className="text-black">Address</Label>
                  <Input id="address" value={signupData.address} onChange={handleSignupChange} className="bg-white text-black" />
                </div>
                <div className="space-y-1">
                  <Label className="text-black">Phone Number</Label>
                  <Input id="phoneNumber" value={signupData.phoneNumber} onChange={handleSignupChange} className="bg-white text-black" />
                </div>
              </CardContent>
              <CardFooter>
                <Button
                  className="w-full bg-black text-white hover:bg-slate-600"
                  onClick={registerUser}
                >
                  Sign up
                </Button>
              </CardFooter>
            </Card>
          </TabsContent>
        </Tabs>
      </div>
    </div>
  );
};

export default Login;
