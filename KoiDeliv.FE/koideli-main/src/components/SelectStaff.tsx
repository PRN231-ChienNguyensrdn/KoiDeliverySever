import {
  Select,
  SelectContent,
  SelectGroup,
  SelectItem,
  SelectLabel,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
const SelectStaff = () => {
  return (
    <Select>
      <SelectTrigger className="w-[180px]">
        <SelectValue placeholder="Select a staff" />
      </SelectTrigger>
      <SelectContent>
        <SelectGroup>
          <SelectLabel>Staff</SelectLabel>
          <SelectItem value="apple">NV A</SelectItem>
          <SelectItem value="banana">NV B</SelectItem>
          <SelectItem value="blueberry">NV C</SelectItem>
          <SelectItem value="grapes">NV D</SelectItem>
          <SelectItem value="pineapple">NV E</SelectItem>
        </SelectGroup>
      </SelectContent>
    </Select>
  );
};

export default SelectStaff;
