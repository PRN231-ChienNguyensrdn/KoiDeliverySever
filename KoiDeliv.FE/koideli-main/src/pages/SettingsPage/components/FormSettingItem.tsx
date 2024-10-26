import { FC } from 'react';
import { FormControl, FormField, FormItem, FormLabel, FormMessage } from '@/components/ui/form';
import { Button } from '@/components/ui/button';
import { Calendar } from '@/components/ui/calendar';
import { Popover, PopoverContent, PopoverTrigger } from '@/components/ui/popover';
import { cn } from '@/lib/utils';
import { format } from 'date-fns';
import { CalendarIcon } from 'lucide-react';
import { Input } from '@/components/ui/input';
interface FormSettingItemProps {
  name: string;
  label: string;
  type: string;
  placeholder: string;
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  form: any;
}

const FormSettingItem: FC<FormSettingItemProps> = ({ form, name, label, type, placeholder }) => {
  return (
    <FormField
      control={form.control}
      name={name}
      render={({ field }) => (
        <FormItem className="flex flex-col items-start lg:col-span-1 sm:col-span-2 xs:col-span-2">
          <FormLabel>{label}</FormLabel>
          {type === 'date' ? (
            <Popover>
              <PopoverTrigger asChild>
                <FormControl>
                  <Button
                    variant={'outline'}
                    className={cn(
                      'lg:w-[80%]  sm:w-full xs:w-full  text-left font-normal',
                      !field.value && 'text-muted-foreground'
                    )}
                  >
                    {field.value ? format(field.value, 'PPP') : <span>Pick a date</span>}
                    <CalendarIcon className="ml-auto h-4 w-4 opacity-50" />
                  </Button>
                </FormControl>
              </PopoverTrigger>
              <PopoverContent className="w-auto p-0" align="start">
                <Calendar
                  mode="single"
                  selected={field.value}
                  onSelect={field.onChange}
                  initialFocus
                />
              </PopoverContent>
            </Popover>
          ) : type === 'color' ? (
            <FormControl className="lg:w-[80%]   sm:w-full xs:w-full ">
              <div className="flex max-w-full  items-center ">
                <Input placeholder={placeholder} {...field} className="border-r-0 rounded-r-none" />
                <div className="h-full w-[40px] flex items-center justify-center border border-input rounded-r-md">
                  <Input
                    className="w-[25px] h-[25px]  border-none m-0 p-0  rounded-full"
                    type="color"
                    {...field}
                  />
                </div>
              </div>
            </FormControl>
          ) : (
            <FormControl className="lg:w-[80%]   sm:w-full xs:w-full ">
              <Input placeholder={placeholder} {...field} type={type} />
            </FormControl>
          )}

          <FormMessage />
        </FormItem>
      )}
    />
  );
};

export default FormSettingItem;
