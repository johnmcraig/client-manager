<template>
  <b-navbar toggleable="lg" type="dark" id="nav">
    <b-navbar-brand :to="{ name: 'Home' }">Home</b-navbar-brand>
    <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>
    <b-collapse id="nav-collapse" is-nav>
      <b-navbar-nav class="flex-grow-1 justify-content-center">
        <b-nav-item class="nav-link text-dark btn btn-outline-light mt-2 ml-2" :to="{ name: 'EmployeeForm' }" >Employee Form</b-nav-item>
        <b-nav-item class="nav-link text-dark btn btn-outline-light mt-2 ml-2" :to="{ name: 'EmployeeTable' }" >Employee Table</b-nav-item>
      </b-navbar-nav>
    </b-collapse>
  </b-navbar>
</template>

<script>
export default {
  name: "Navbar"
};
</script>

<style>
nav {
  background-color: #3274d3;
}
.nav a {
    color: #fff;
}
</style>
