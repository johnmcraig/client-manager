<template>
    <div id="app">
        <navbar />
        <router-view />
    </div>
</template>

<script>
import Navbar from '@/components/ui/Navbar'

export default {
  name: 'app',
  components: {
    Navbar
  }
}
</script>

<style>
</style>
