import { Button } from '@/components/ui/button';
import * as yup from 'yup';
import { Form } from '@/components/ui/form';
import { yupResolver } from '@hookform/resolvers/yup';
import { SubmitHandler, useForm } from 'react-hook-form';
import { useMemo } from 'react';
import FormSettingItem from './components/FormSettingItem';

interface IInputs {
  title: string;
  email: string;
  color: string;
  date: Date;
}

const SettingsPage = () => {
  const schema = yup.object().shape({
    date: yup.date().optional().required(),
    title: yup.string().required(),
    email: yup.string().email().required(),
    color: yup.string().required(),
  });
  const form = useForm<IInputs>({
    resolver: yupResolver(schema),
    defaultValues: {
      title: '',
      email: '',
      color: '',
      date: new Date(),
    },
  });
  const {
    formState: { isDirty },
  } = form;

  const onSubmit: SubmitHandler<IInputs> = (data) => {
    console.log(data);
  };

  const data = useMemo(
    () => [
      {
        name: 'title',
        label: 'Title: ',
        type: 'string',
        placeholder: '',
      },
      {
        name: 'email',
        label: 'Email: ',
        type: 'string',
        placeholder: '',
      },
      {
        name: 'color',
        label: 'Background color: ',
        type: 'color',
        placeholder: '',
      },
      {
        name: 'date',
        label: 'Active date: ',
        type: 'date',
        placeholder: '',
      },
    ],
    []
  );
  return (
    <div className="px-5 mx-5">
      <div className="my-5">
        <h3 className="text-3xl font-bold tracking-tight text-start">Settings</h3>
      </div>
      <Form {...form}>
        <form
          onSubmit={form.handleSubmit(onSubmit)}
          className="grid grid-cols-2 border rounded-lg my-5  px-10 py-8 gap-4 "
        >
          {data.map((item) => (
            <FormSettingItem {...item} form={form} key={item.name} />
          ))}
          {isDirty && (
            <div className="col-span-2">
              <Button type="submit">Submit</Button>
            </div>
          )}
        </form>
      </Form>
    </div>
  );
};

export default SettingsPage;
