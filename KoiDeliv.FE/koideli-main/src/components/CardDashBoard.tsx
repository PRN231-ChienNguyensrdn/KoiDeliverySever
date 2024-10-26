import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { User } from "lucide-react";
const CardDashBoard = ({ title = "Total user", total = 10, desc = "" }) => {
  return (
    <Card>
      <CardHeader>
        <CardTitle className="text-white ">{title}</CardTitle>
        <CardDescription>{desc}</CardDescription>
      </CardHeader>
      <CardContent>
        <div className="flex justify-center items-center gap-3">
          <p className="text-2xl font-medium text-center">{total}</p>
          <div className="g-slate-100 bg-gray-100 p-2 flex items-center justify-center rounded-full">
            <User className="text-slate-950" />
          </div>
        </div>
      </CardContent>
    </Card>
  );
};

export default CardDashBoard;
