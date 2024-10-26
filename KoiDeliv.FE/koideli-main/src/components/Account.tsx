import { useUser } from "@/context";
import { Avatar, AvatarFallback, AvatarImage } from "./ui/avatar";

const Account = () => {
  const { state } = useUser();
  if (!state?.data?.email)
    return (
      <Avatar className="h-8 w-8">
        <AvatarImage src="https://github.com/shadcn.png" alt="@shadcn" />
        <AvatarFallback>CN</AvatarFallback>
      </Avatar>
    );

  return (
    <Avatar className="h-8 w-8 bg-slate-50">
      <AvatarImage alt={state?.data?.name} />
      <AvatarFallback className="bg-slate-50 border-slate-950 border-solid border-2 text-slate-900">
        {state?.data?.name?.[0]}
      </AvatarFallback>
    </Avatar>
  );
};

export default Account;
