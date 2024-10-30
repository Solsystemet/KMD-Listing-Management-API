import { createRootRoute, Link, Outlet } from "@tanstack/react-router";
import { TanStackRouterDevtools } from "@tanstack/router-devtools";
import { Navbar } from "../components/navbar/Navbar";
import "./../index.css";

export const Route = createRootRoute({
   component: () => (
      <>
         <Navbar
            children={[
               { url: "/home", label: "Home" },
               { url: "/about", label: "About" },
               { url: "/contact", label: "Contact" },
            ]}
         />
         <Outlet />
         <TanStackRouterDevtools />
      </>
   ),
});
