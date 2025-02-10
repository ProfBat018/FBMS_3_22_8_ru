import fastify from 'fastify'
import { authRoutes } from './routes/appRoutes.ts'

const app = fastify({ logger: true })

const appListenOptions = {
    port: 3000,
}
app.register(authRoutes)

app.listen(appListenOptions, () => {
  console.log('Server listening on http://localhost:3000')
})
