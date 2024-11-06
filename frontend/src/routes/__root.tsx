import { createRootRoute, Outlet } from "@tanstack/react-router";
import { TanStackRouterDevtools } from "@tanstack/router-devtools";
import { Navbar } from "../components/navbar/Navbar";
import "./../index.css";

export const Route = createRootRoute({
   component: () => (
      <>
         <Navbar children={[{ url: "/uploadPage", label: "Create Listing" }]} />
         <Outlet />
         <TanStackRouterDevtools />
      </>
   ),
});
