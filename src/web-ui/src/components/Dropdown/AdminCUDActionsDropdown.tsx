"use client";
import React from "react";
import { Dropdown, DropdownTrigger, DropdownMenu, DropdownItem, Button, cn, Link } from "@nextui-org/react";
import { TrashIcon } from "@/icons/Trash";
import { PlusIcon } from "@/icons/Plus";
import { EditIcon } from "@/icons/Edit";

export default function AdminCUDActionsDropdown() {
    return (
        <Dropdown backdrop="blur">
            <DropdownTrigger>
                <Button color="primary" variant="light">
                    Category
                </Button>
            </DropdownTrigger>
            <DropdownMenu variant="light" aria-label="Dropdown menu with icons">
                <DropdownItem key="new" description="Create a new category" className="text-primary" color="primary" href="dashboard/categories/new">
                    Create New Category
                </DropdownItem>
                <DropdownItem key="edit" description="Edit an existing category" className="text-warning" color="warning">
                    Update Existing Category
                </DropdownItem>
                <DropdownItem key="delete" description="Remove a category permanently" className="text-danger" color="danger">
                    Delete Category
                </DropdownItem>
            </DropdownMenu>
        </Dropdown>
    );
}
