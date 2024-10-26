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
const Login = () => {
  const { state, dispatch } = useUser();
  console.log("🚀 ~ Login ~ state:", state);
  const updateUser = () => {
    dispatch({
      type: "UPDATE_USER",
      payload: { name: "Nhat", email: "nhat@nt" },
    });

    dispatch({
      type: "TOGGLE_ADMIN",
    });
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
                  <Label htmlFor="name" className="text-black">
                    Email
                  </Label>
                  <Input
                    id="name"
                    defaultValue=""
                    className="bg-white text-black"
                  />
                </div>
                <div className="space-y-1">
                  <Label htmlFor="pass" className="text-black">
                    Password
                  </Label>
                  <Input
                    id="pass"
                    defaultValue=""
                    className="bg-white text-black"
                  />
                </div>
              </CardContent>
              <CardFooter>
                <Button
                  className="w-full bg-black text-white hover:bg-slate-600"
                  onClick={updateUser}
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
                  <Label htmlFor="name" className="text-black">
                    Email
                  </Label>
                  <Input
                    id="name"
                    defaultValue=""
                    className="bg-white text-black"
                  />
                </div>
                <div className="space-y-1">
                  <Label htmlFor="pass" className="text-black">
                    Password
                  </Label>
                  <Input
                    id="pass"
                    defaultValue=""
                    className="bg-white text-black"
                  />
                </div>
                <div className="space-y-1">
                  <Label htmlFor="confirm" className="text-black">
                    Confirm password
                  </Label>
                  <Input
                    id="confirm"
                    defaultValue=""
                    className="bg-white text-black"
                  />
                </div>
              </CardContent>
              <CardFooter>
                <Button
                  className="w-full bg-black text-white hover:bg-slate-600"
                  onClick={updateUser}
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
