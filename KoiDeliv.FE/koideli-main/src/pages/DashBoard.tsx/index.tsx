import CardDashBoard from "@/components/CardDashBoard";
import ChartDashBoard from "@/components/ChartDashBoard";

const Dashboard = () => {
  return (
    <div className="my-5  flex flex-col gap-4 px-10 ">
      <h3 className="text-3xl font-bold tracking-tight text-start text-white ">
        Dashboard
      </h3>
      {/* <div className="flex gap-2 ">
        {listButton.map((item) => (
          <Button
            size={'sm'}
            key={item.id}
            variant={value === item.id ? 'default' : 'outline'}
            onClick={() => handleClick(item.id)}
            className="px-10 rounded-full"
          >
            {item.text}
          </Button>
        ))}
      </div> */}
      <div className="grid auto-rows-min gap-4 md:grid-cols-3">
        <CardDashBoard
          title="Total user"
          desc="Displays the current total number of users in the system."
          total={10}
        />
        <CardDashBoard
          title="Total user"
          desc="Displays the current total number of users in the system."
          total={10}
        />
        <CardDashBoard
          title="Total user"
          desc="Displays the current total number of users in the system."
          total={10}
        />
      </div>
      {/* <div className="-5">{children}</div> */}
      <ChartDashBoard />
      {/* <PostManagement/> */}
    </div>
  );
};

export default Dashboard;
