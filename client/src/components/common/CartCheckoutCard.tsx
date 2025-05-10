import React, { useEffect, useState } from "react";
import { CartItem } from "@/types/types/cart/CartItem";
import { Book, ServiceResponse } from "@/types";
import { fetchBookByIdService } from "@/services/bookService";
import { addNotification } from "@/state/redux/slices/notificationSlice";
import { AppDispatch } from "@/state/redux";
import { useDispatch } from "react-redux";
import "@/assets/styles/components/common/cart-checkout-card.css"

interface CartCheckoutCardProps {
    edit?: boolean
    item: CartItem
    onAdd: (item: CartItem) => void;
    onRemove: (item: CartItem) => void;
    onItemClear: (bookId: string) => void;
}

const CartCheckoutCard: React.FC<CartCheckoutCardProps> = ({ edit, item, onAdd, onRemove, onItemClear }) => {
    const dispatch = useDispatch<AppDispatch>()
    const [book, setBook] = useState<Book | null>();
    const [serviceResponse, setServiceResponse] = useState<
        ServiceResponse<Book>
    >({
        data: null,
        loading: true,
        error: null,
    })

    useEffect(() => {
        (async () => {
            const response = await fetchBookByIdService(item.bookId);
            setServiceResponse(response);
            if (response.error)
                dispatch(addNotification({ message: response.error, type: 'error' }));
            setBook(response.data);
        })();
    }, [item, dispatch])



    return (
        <div>
            <div className="flex gap-[14px] text-dark relative">
                <img src={`https://picsum.photos/seed/${item.bookId}/50/75`} className="w-[50px] h-[75px]" />
                <div className="flex flex-col gap-4  w-full">
                    <div>
                        <div className="flex justify-between">
                            <p className="text-black">{book?.title}</p>
                            {edit ? (
                                <p className="delete-btn"
                                    onClick={() => onItemClear(item.bookId)}>
                                    Delete
                                </p>)
                                :
                                (<p>{item.amount} pcs.</p>)}
                        </div>
                        <p className="text-gray">AUTHOR_TMP</p>

                        <p>{book?.price} UAH</p>
                        <p className="text-accent">{(book?.quantity ?? 0 > 0) ? "Available" : "Not available"}</p>
                    </div>
                </div>
            </div>
            <div className="flex justify-center items-center">
            {edit ? (
                    <div className="flex gap-2.5 items-center">
                        <p className="counter-btn" onClick={() => onRemove(item)}>-</p>
                        <div className="item-counter-container">
                            <p className="item-counter">{item.amount} psc</p>
                        </div>
                        <p className="counter-btn" onClick={() => onAdd(item)}>+</p>
                    </div>)
                    : ""}
            </div>
        </div>
    )
}

export default CartCheckoutCard