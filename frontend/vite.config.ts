// vite.config.ts
import { defineConfig } from "vite";
import viteReact from "@vitejs/plugin-react";
import { TanStackRouterVite } from "@tanstack/router-plugin/vite";

// https://vitejs.dev/config/
export default defineConfig({
   plugins: [
      TanStackRouterVite(),
      viteReact(),
      // ...,
   ],
   build: {
      outDir: "../api/wwwroot",
      emptyOutDir: true,
   },

   server: {
      proxy: {
         "/api": {
            target: "http://localhost:5047",
            changeOrigin: true,
         },
      },
   },
});
