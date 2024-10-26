import TableManager from "@/pages/PostManagementPage/components/TableManager";
import TablePagination from "@/pages/PostManagementPage/components/TablePagination";
import TableToolbar from "@/pages/PostManagementPage/components/TableToolbar";
import { getPosts } from "@/service/postService";
import { IPost } from "@/types";
import { useCallback, useEffect, useState } from "react";

import { useNavigate, useParams } from "react-router-dom";
import { toast } from "sonner";
const ListOrder = () => {
  const navigate = useNavigate();
  // const [searchParams] = useSearchParams();
  const [value, setValue] = useState<string>("userId");
  const [data, setData] = useState<IPost[]>([]);
  const [isLoading, setIsLoading] = useState(false);
  const [filters, setFilters] = useState({
    _page: 1,
    _limit: 10,
    // userId: "",
    // title: "",
  });
  const [selected, setSelected] = useState<IPost[]>([]);
  const { id } = useParams();
  const fetchData = useCallback(async () => {
    try {
      setIsLoading(true);
      const res = await getPosts(filters);
      setData(() => res);
      if (!id) {
        // const _filters = cleanObject({ ...filters }) as Record<string, string>;
        // navigate(`/admin/${paths.ordersManagement}?${new URLSearchParams(_filters).toString()}`, {
        //   replace: true,
        // });
      }
    } catch (error) {
      toast.error("Something went wrong");
      navigate("/");
    } finally {
      setIsLoading(false);
    }
  }, [filters, navigate, id]);

  const handleCheckAll = useCallback(
    (checked: boolean) => {
      if (checked) {
        setSelected(() => data);
        return;
      }
      setSelected(() => []);
    },
    [data]
  );

  const handleCheckItem = useCallback((checked: boolean, post: IPost) => {
    if (checked) {
      setSelected((prev) => [...prev, post]);
      return;
    }
    setSelected((prev) => prev.filter((item) => item.id !== post.id));
  }, []);

  const handleChangePerPage = useCallback((value: number) => {
    setFilters((prev) => ({
      ...prev,
      _page: 1,
      _limit: value,
    }));
  }, []);

  const handleChangePage = useCallback((value: number) => {
    setFilters((prev) => ({
      ...prev,
      _page: value,
    }));
  }, []);

  useEffect(() => {
    fetchData();
    setSelected(() => []);
  }, [JSON.stringify(filters)]);
  return (
    <div>
      <TableToolbar
        value={value}
        setValue={setValue}
        filters={filters}
        setFilters={setFilters}
      />
      <TableManager
        data={data}
        isLoading={isLoading}
        itemSelected={selected}
        limit={filters._limit}
        handleCheckAll={handleCheckAll}
        handleCheckItem={handleCheckItem}
        isAdmin={false}
      />
      <TablePagination
        data={data}
        filters={filters}
        handleChangePage={handleChangePage}
        handleChangePerPage={handleChangePerPage}
        isLoading={isLoading}
        itemSelected={selected}
      />
    </div>
  );
};

export default ListOrder;
