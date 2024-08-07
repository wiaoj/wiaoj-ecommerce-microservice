"use client";
import { Button, Input } from "@nextui-org/react";
import React, { useState } from "react";
import { toast } from "react-toastify";

export default function CreateCategoryPage() {
    const [categoryName, setCategoryName] = useState("");

    const handleSubmit = async (event: React.FormEvent) => {
        event.preventDefault();

        const response = await fetch("https://localhost:5001/api/categories", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({ name: categoryName }),
        });

        const data = await response.json();

        if (response.ok || response.status === 201) {
            toast.success(`Category "${data.categoryName}" created successfully!`);
            setCategoryName("");
        } else {
            toast.error(`Error: ${data.message}`, {
                position: "top-right",
                autoClose: 5000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                progress: undefined,
            });
        }
    };

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <Input type="text" variant="flat" label="Category Name" value={categoryName} onChange={(e) => setCategoryName(e.target.value)} />
                <Button color="success" type="submit">
                    Create
                </Button>
            </form>
        </div>
    );
}
