import { useState } from "react";
import type { ReactNode } from "react";
import { Link, useLocation } from "react-router-dom";
import {
  AppBar,
  Toolbar,
  Typography,
  Drawer,
  List,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  Box,
  IconButton,
  Menu,
  MenuItem,
  Avatar,
} from "@mui/material";
import AssignmentIcon from "@mui/icons-material/Assignment";
import AssignmentIndIcon from "@mui/icons-material/AssignmentInd";
import BusinessIcon from "@mui/icons-material/Business";
import { useAuth } from "../../auth/AuthContext";

const DRAWER_WIDTH = 240;

const navItems = [
  { label: "Tüm Görevler", path: "/", icon: <AssignmentIcon /> },
  { label: "Bana Atanan Görevler", path: "/assigned", icon: <AssignmentIndIcon /> },
  { label: "Departmanlar", path: "/departments", icon: <BusinessIcon  /> },];

export function AppLayout({ children }: { children: ReactNode }) {
  const { user, logout } = useAuth();
  const location = useLocation(); 

  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);

  function handleLogout() {
    setAnchorEl(null);
    logout(); 
  }

  return (
    <Box sx={{ display: "flex" }}>
      <AppBar
        position="fixed"
        sx={{ width: `calc(100% - ${DRAWER_WIDTH}px)`, ml: `${DRAWER_WIDTH}px` }}
      >
        <Toolbar sx={{ justifyContent: "space-between" }}>
          <Typography variant="h6">Görev Yönetim Sistemi</Typography>

          <IconButton onClick={(e) => setAnchorEl(e.currentTarget)}>
            <Avatar sx={{ width: 32, height: 32 }}>
              {user?.userName?.charAt(0).toUpperCase()}
            </Avatar>
          </IconButton>

          <Menu
            anchorEl={anchorEl}
            open={Boolean(anchorEl)}
            onClose={() => setAnchorEl(null)}
          >
            <MenuItem disabled>
              {user?.userName} — {user?.departmentName}
            </MenuItem>
            <MenuItem onClick={handleLogout}>Çıkış Yap</MenuItem>
          </Menu>
        </Toolbar>
      </AppBar>

      <Drawer
        variant="permanent"
        sx={{
          width: DRAWER_WIDTH,
          flexShrink: 0,
          [`& .MuiDrawer-paper`]: { width: DRAWER_WIDTH, boxSizing: "border-box" },
        }}
      >
        <Toolbar /> 
        <List>
          {navItems.map((item) => (
            <ListItemButton
              key={item.path}
              component={Link} 
              to={item.path}
              selected={location.pathname === item.path}
            >
              <ListItemIcon>{item.icon}</ListItemIcon>
              <ListItemText primary={item.label} />
            </ListItemButton>
          ))}
        </List>
      </Drawer>

      <Box component="main" sx={{ flexGrow: 1, p: 3 }}>
        <Toolbar /> 
        {children}
      </Box>
    </Box>
  );
}