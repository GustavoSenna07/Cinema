import { Search, Ticket} from "lucide-react";

export default function HeaderUser() {
  return (
    <div className="flex justify-end items-center p-2 gap-4">
      <Search size={30} color="black" />
      <Ticket  size={30} color="black" />
    </div>
  )
}